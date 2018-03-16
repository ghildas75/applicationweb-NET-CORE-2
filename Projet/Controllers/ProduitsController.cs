



using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Projet.Data.Interfaces;
using Projet.Models;
using Projet.ViewModels;
using Projet.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Projet.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProduitRepository _produitRepository;
        private readonly ISession _session;

        public ProduitsController(ICategoryRepository categoryRepository, IProduitRepository produitRepository, IHttpContextAccessor context)
        {
            _categoryRepository = categoryRepository;
            _produitRepository = produitRepository;
            _session = context.HttpContext.Session;

        }

        public IActionResult Paginer(int page = 0, int size = 5, int flag = 0)
        {

            //_session.SetInt32("flag", 1);

            if (flag == 2)
                _session.SetInt32("size", size);
            else if ((int)_session.GetInt32("flag") == 1)
            {

                if (_session.GetInt32("size") != null)
                    size = (int)_session.GetInt32("size");
                else
                    size = 5;

            }



            int position = page * size;
            List<Produit> produits;
            int nbreProduit;
            if (TempData["category"] != null)
            {

                produits = _produitRepository.Produits.Where(p => p.Category.CategoryId == Convert.ToInt32(TempData["category"])).Skip(position).Take(size).ToList();
                ViewBag.CurrentPage = page;
                nbreProduit = _produitRepository.Produits.Where(p => p.Category.CategoryId == Convert.ToInt32(TempData["category"])).ToList().Count();
            }
            else if (_session.GetInt32("category") != null)
            {

                var Id = _session.GetInt32("category");
                produits = _produitRepository.Produits.Where(p => p.Category.CategoryId == Id).Skip(position).Take(size).ToList();
                ViewBag.CurrentPage = page;
                nbreProduit = _produitRepository.Produits.Where(p => p.Category.CategoryId == Id).ToList().Count();

            }
            else
            {

                produits = _produitRepository.Produits.Skip(position).Take(size).ToList();
                ViewBag.CurrentPage = page;
                nbreProduit = _produitRepository.Produits.Count();

            }

            int totalPages;
            if (nbreProduit % size == 0)
                totalPages = nbreProduit / size;

            else
                totalPages = 1 + (nbreProduit / size);
            //totalPages = _produitRepository.Produits.ToList().Count() / size;
            ViewBag.TotalPages = totalPages;
            return View(produits);
        }

        public ViewResult List(string category)
        {

            string _category = category;
            IEnumerable<Produit> produits;
            string CurrentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                produits = _produitRepository.Produits.OrderBy(p => p.ProduitId);
                CurrentCategory = "ALL Product ";
            }
            else
            {
                if (string.Equals("Ordinateur", _category, StringComparison.OrdinalIgnoreCase))


                    produits = _produitRepository.Produits.Where(p => p.Category.CategoryName.Equals("Ordinateurs"));


                if (string.Equals("Imprimantes", _category, StringComparison.OrdinalIgnoreCase))

                    produits = _produitRepository.Produits.Where(p => p.Category.CategoryName.Equals("Imprimantes"));

                else
                    produits = _produitRepository.Produits.Where(p => p.Category.CategoryName.Equals("Tabelettes"));



                CurrentCategory = _category;
            }

            var ProduitListViewModel = new ProduitListViewModels
            {
                Produits = produits,
                CurrentCategory = CurrentCategory

            };
            return View(ProduitListViewModel);
            //    ProduitListViewModels vm = new ProduitListViewModels { Produits = _produitRepository.Produits,
            //    CurrentCategory = "ordinateur"
            //};
            //    if (vm.Produits!=null)
            //    {

            //        return View(vm);
            //    }

        }

        public ViewResult FindProductByDescription(String keyWord)
        {
            IEnumerable<Produit> produits = _produitRepository.FindProductByDescription(keyWord).OrderBy(p=>p.AskedPrice).Take(9);
            return View(produits);
        }
    }
}
