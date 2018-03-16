using Microsoft.AspNetCore.Mvc;
using Projet.Models;
using Projet.Models.ShoppingCart;
using Projet.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Projet.ViewModels;
using System;
using System.Linq;

namespace Projet.Controllers
{
    public class OrderController : Controller

    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult CheckOut()
        {

            List<SelectListItem> provinces = new List<SelectListItem>
                  {
                     new SelectListItem { Value = "TO", Text="Toronto" },
                     new SelectListItem { Value = "QC", Text="Quebec" },
                     new SelectListItem { Value = "NB", Text="Nouveau Brunswick" }

                   };

            ViewBag.provinces = provinces;

            List<SelectListItem> countries = new List<SelectListItem>
                  {
                     new SelectListItem { Value = "Canada", Text="Canada" }

                   };

            ViewBag.countries = countries;


            List<SelectListItem> payements = new List<SelectListItem>
                  {
                     new SelectListItem { Value = "VISA", Text="VISA" },
                     new SelectListItem { Value = "Master Card", Text="Master Card" },
                     new SelectListItem { Value = "Amex", Text="Amex" }

                   };

            ViewBag.payements = payements;
            return View();
        }


        [HttpPost]
        public IActionResult CheckOut(OrderViewModel orderVM)
        {
           
            var items = _shoppingCart.GetCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {

                ModelState.AddModelError("", "Your cart is empty, add some product first!");

            }

            if (ModelState.IsValid)
            {
                var order = new Order()
                {

                    Address = orderVM.Address,
                    OrderDate = DateTime.Now,
                    Email = orderVM.Email,
                    Payement = orderVM.Payement,
                    City = orderVM.City,
                    Country = orderVM.Country,
                    FirstName = orderVM.FirstName,
                    LastName = orderVM.LastName,
                    Username = User.Identity.Name,
                    PhoneNumber = orderVM.PhoneNumber,
                    Province = orderVM.Province,
                    PostalCode = orderVM.PostalCode


                };
                //_orderRepository.CreateOrder(order);
                // _shoppingCart.ClearCart();

                //Save Order
                _orderRepository.getContext().orders.Add(order);
                _orderRepository.getContext().SaveChanges();
                //Process the order
                //var cart = ShoppingCart.GetCart(_);
                _shoppingCart.CreateOrder(order);




                return RedirectToAction("CheckOutComplete", new { id = order.OrderId });
            }

            List<SelectListItem> provinces = new List<SelectListItem>
                  {
                     new SelectListItem { Value = "TORONTO", Text="Toronto" },
                     new SelectListItem { Value = "Quebec", Text="Quebec" },
                     new SelectListItem { Value = "Nouveau Brunswick", Text="Nouveau Brunswick" }

                   };

            ViewBag.provinces = provinces;

            List<SelectListItem> countries = new List<SelectListItem>
                  {
                     new SelectListItem { Value = "CANADA", Text="Canada" }

                   };

            ViewBag.countries = countries;


            List<SelectListItem> payements = new List<SelectListItem>
                  {
                     new SelectListItem { Value = "VISA", Text="VISA" },
                     new SelectListItem { Value = "Master Card", Text="Master Card" },
                     new SelectListItem { Value = "AmeX", Text="Amex" }

                   };

            ViewBag.payements = payements;


            return View(orderVM);
        }

        public IActionResult CheckOutComplete(int id)
        {

            // Validate customer owns this order
            bool isValid = _orderRepository.getContext().orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("ErrorOnCommand");
            }
        }
    }
}