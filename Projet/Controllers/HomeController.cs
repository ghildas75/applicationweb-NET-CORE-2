using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.ViewModels;
using Projet.Data.Interfaces;
using Projet.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Projet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduitRepository _produitRepository;

        public ICategoryRepository _categoryRepository { get; }

        private readonly ISession _session;

        public HomeController(IProduitRepository produitRepository, ICategoryRepository categoryRepository, IHttpContextAccessor context)
        {
            _produitRepository = produitRepository;
            _categoryRepository = categoryRepository;
            _session = context.HttpContext.Session;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {

                PopularProduit = _produitRepository.PopularProduit
            };
            return View(homeViewModel);
        }

        public IActionResult Browse(int Id = 1)
        {

            var categoryMDL = _categoryRepository.getCategoryById(Id);
            return View(categoryMDL.Produits.Where(p => p.isPopular = true).Take(9));
        }

        [Authorize]
        public IActionResult More(int Id = 1)
        {
            var categoryMDL = _categoryRepository.getCategoryById(Id);
            TempData["category"] = Id;
            _session.SetInt32("category", Id);
            _session.SetInt32("flag", 1);

            return RedirectToAction("Paginer", "Produits");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
