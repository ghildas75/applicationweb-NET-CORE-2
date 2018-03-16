using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.Models.ShoppingCart;
using Projet.ViewModels;
using System.Collections.Generic;

namespace Projet.Views.ViewComponents
{
    public class _SommairePanier: ViewComponent
    {
        private ShoppingCart _shoppingCart;

        public _SommairePanier(ShoppingCart spc)
        {
            _shoppingCart = spc;
        }
        public IViewComponentResult Invoke() {

            var items = _shoppingCart.GetCartItems();
            //var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() };
            _shoppingCart.ShoppingCartItems = items;

            var panierViewModel = new PanierViewModel
            {

                ShoppingCart = _shoppingCart,
                Total = _shoppingCart.GetShoppingCartTotal()
            };

            return View(panierViewModel);
        }
    }
}
