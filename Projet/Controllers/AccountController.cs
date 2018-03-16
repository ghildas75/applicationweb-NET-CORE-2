using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Projet.Models;
using Projet.Models.AccountViewModels;
using Projet.Services;
using Projet.Interfaces;
using Projet.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace Projet.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IClientRepository _clientsRepo;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public static ISession _session;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IClientRepository clientsRepo,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _clientsRepo = clientsRepo;
            _emailSender = emailSender;
            _logger = logger;
            _session = context.HttpContext.Session;

        }

        ////////////////////////

        private async Task CreateRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //initializing custom roles 
            //var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            //var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Gerant", "Gestionnaire" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            var gerant = new ApplicationUser
            {

                UserName = "Gerant",
                Email = "gerant@ecommerce.com",

            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = "Gerant1!";
            var _user = await userManager.FindByEmailAsync("gerant@ecommerce.com");

            if (_user == null)
            {
                var createGerant = await userManager.CreateAsync(gerant, userPWD);
                if (createGerant.Succeeded)
                {
                    //here we tie the new user to the role
                    await userManager.AddToRoleAsync(gerant, "Gerant");
                    //await dbContext.SaveChangesAsync();
                    //add gerant as a client important for login process
                    var newGerant = new Client()
                    {

                        FirstName = "gerant",
                        LastName = "gerant",
                        Address = "",
                        City = "",
                        Province = "",
                        Country = "",
                        PostalCode = "",
                        PhoneNumber ="",
                        CreateDate = DateTime.Now,
                        LastConnected = DateTime.Now,
                        ConnexionNumber = 1,
                        CreatedBy = "Administrator",
                        Email = "gerant@ecommerce.com"


                    };

                    _clientsRepo.ClientInsert(newGerant);


                }

            }
            /*++++++++++++++++++ Gestionnaire ++++++++++++++++++++++*/

            var gestionnaire = new ApplicationUser
            {

                UserName = "Gestionnaire",
                Email = "gestionnaire@ecommerce.com",
            };
            //Ensure you have these values in your appsettings.json file
            string userManagerPWD = "Gestionnaire1!";
            var _gestionnaire = await userManager.FindByEmailAsync("gestionnaire@ecommerce.com");

            if (_gestionnaire == null)
            {
                var createGestionnaireUser = await userManager.CreateAsync(gestionnaire, userManagerPWD);
                if (createGestionnaireUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await userManager.AddToRoleAsync(gestionnaire, "Gestionnaire");
                    //await dbContext.SaveChangesAsync();

                    //add gestionnaire as a client important for login process
                    var newGestionnaire = new Client()
                    {

                        FirstName = "gestionnaire",
                        LastName = "gestionnaire",
                        Address = "",
                        City = "",
                        Province = "",
                        Country = "",
                        PostalCode = "",
                        PhoneNumber = "",
                        CreateDate = DateTime.Now,
                        LastConnected = DateTime.Now,
                        ConnexionNumber = 1,
                        CreatedBy = "Administrator",
                        Email = "gestionnaire@ecommerce.com"


                    };

                    _clientsRepo.ClientInsert(newGestionnaire);

                }
            }


        }



        ///////////////////////







        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                ApplicationUser signedUser = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    var client  = _clientsRepo.FindClientByEmail(model.Email);
                    client.ConnexionNumber++;
                    client.LastConnected = DateTime.Now;
                    _clientsRepo.updateClient(client);

                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, RemebreMe = false/*model.RememberMe*/ });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var model = new LoginWith2faViewModel { RememberMe = rememberMe };
            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            List<SelectListItem> provinces = new List<SelectListItem>
            {
                new SelectListItem { Value = "TO", Text="Toronto" },
                new SelectListItem { Value = "QC", Text="Quebec"},
                new SelectListItem { Value = "NB", Text="Nouveau Brunswick" }
            };
            List<SelectListItem> countries = new List<SelectListItem>
            {
                new SelectListItem { Value = "CA", Text="Canada" }
               
            };

            ViewBag.provinces = provinces;
            ViewBag.countries = countries;
            CreateRoles(_userManager, _roleManager).Wait();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                _clientsRepo.SaveChanges();
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    // create a new client instance

                    var newClient = new Client()
                    {

                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        City = model.City,
                        Province = model.Province,
                        Country = model.Country,
                        PostalCode = model.PostalCode,
                        PhoneNumber = model.PhoneNumber,
                        CreateDate = DateTime.Now,
                        LastConnected = DateTime.Now,
                        ConnexionNumber = 1,
                        CreatedBy = "Self",
                        Email = model.Email


                    };

                    _clientsRepo.ClientInsert(newClient);

                    Client client = _clientsRepo.FindClientByEmail(model.Email);
                    _session.SetString("Nom", newClient.FirstName + " " + newClient.LastName);
                    _session.SetString("Email", newClient.Email);
                    _session.SetString("Password", model.Password);
                    _session.SetInt32("NumeroClient", client.clientID);

                    EmailSenderExtensions._session = _session; // handoff session to EmailSender

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);
                    user.EmailConfirmed = true;

                    await _signInManager.SignInAsync(user, isPersistent: true);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            List<SelectListItem> provinces = new List<SelectListItem>
            {
                new SelectListItem { Value = "TO", Text="Toronto" },
                new SelectListItem { Value = "QC", Text="Quebec"},
                new SelectListItem { Value = "NB", Text="Nouveau Brunswick" }
            };
            List<SelectListItem> countries = new List<SelectListItem>
            {
                new SelectListItem { Value = "CA", Text="Canada" }

            };

            ViewBag.provinces = provinces;
            ViewBag.countries = countries;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Browse), "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = await _userManager.FindByEmailAsync(model.Email.Trim());
                //ApplicationUser user1 = await _userManager.FindByEmailAsync(model.Email.Trim());

                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.More), "Home");
            }
        }

        #endregion
    }
}
