using Microsoft.AspNetCore.Mvc;
using Projet.Data.Interfaces;
using Projet.Models.ShoppingCart;
using Projet.ViewModels;

namespace Projet.Controllers
{
    public class PanierController : Controller
    {
        private readonly IProduitRepository _prodRepo;
        private readonly ShoppingCart _shoppingCart;

        public PanierController(IProduitRepository prodRepo, ShoppingCart shoppingCart)
        {
            _prodRepo = prodRepo;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var panierViewModel = new PanierViewModel
            {

                ShoppingCart = _shoppingCart,
                Total = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(panierViewModel);
        }

        //public IActionResult AddToCart(int produitID)
        //{

        //    var selectedProduit = _prodRepo.Produits.FirstOrDefault(p => p.ProduitId == produitID);

        //}
    }
}