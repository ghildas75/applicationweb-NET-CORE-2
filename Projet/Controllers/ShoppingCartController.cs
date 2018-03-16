using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Projet.Data.Interfaces;
using Projet.ViewModels;
using Projet.Models.ShoppingCart;

namespace Projet.Controllers
{
    public class ShoppingCartController : Controller
    { 
        private readonly IProduitRepository _produitRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProduitRepository produitRepository, ShoppingCart shoppingCart)
        {
            _produitRepository = produitRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var vm = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                shoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(vm);
        }
        public IActionResult AddToShoppingCart(int produitId)
        {
            var selectProd = _produitRepository.Produits.FirstOrDefault(p => p.ProduitId ==produitId);
            if (selectProd !=null)
            {
                _shoppingCart.AddToCart(selectProd, 1);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromShoppingCart(int produitId)
        {
            var selectProd = _produitRepository.Produits.FirstOrDefault(p => p.ProduitId == produitId);
            if (selectProd != null)
            {
                _shoppingCart.RemoveFromCart(selectProd);
            }
            return RedirectToAction("Index");
        }
    }
}