using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projet.Data;
using Projet.Models;
using Projet.Services;
using Projet.Data.Interfaces;
using Projet.Models.Repositories;
using Projet.Models.ShoppingCart;
using Microsoft.AspNetCore.Http;
using Projet.Interfaces;
using Projet.configuration;
using System;
using System.Threading.Tasks;

namespace Projet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string connection = @"Server=(localdb)\mssqllocaldb;Database=DbProject;Trusted_Connection=True;";
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            // Add application services.
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(spc => ShoppingCart.GetCart(spc));
            services.AddMemoryCache();
            services.AddSession();
            // add respos here
            services.AddTransient<IProduitRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClientRepository, ClientsRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();


            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Browse}/{id?}");
            });

            // here a call to create a roles
            //CreateRoles(serviceProvider).Wait();

        }



        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
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
                    await dbContext.SaveChangesAsync();

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
                    await dbContext.SaveChangesAsync();

                }
            }

            
        }

    }
}
