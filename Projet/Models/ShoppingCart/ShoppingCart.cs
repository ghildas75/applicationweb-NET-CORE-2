using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.ShoppingCart
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _dbContext;

        public ShoppingCart(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        } // GetCart

        public void AddToCart(Produit produit, int quantity)
        {

            var shoppingCartItem = _dbContext.cartItems.SingleOrDefault(i => i.Produit.ProduitId == produit.ProduitId && i.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Produit = produit,
                    Amount = 1,
                    CartStatus = true,
                    DateAjout = DateTime.Now

                };

                _dbContext.cartItems.Add(shoppingCartItem);
            }
            else
            {

                shoppingCartItem.Amount++;

            }

            _dbContext.SaveChanges();

        } // Add To Cart

        public int RemoveFromCart(Produit produit)
        {

            var shoppingCartItem = _dbContext.cartItems.SingleOrDefault(i => i.Produit.ProduitId == produit.ProduitId && i.ShoppingCartId == ShoppingCartId);
            var quantity = 0;

            if (shoppingCartItem != null)
            {

                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    quantity = shoppingCartItem.Amount;
                    
                }
                else
                {
                    _dbContext.cartItems.Remove(shoppingCartItem);
                }

            }

            _dbContext.SaveChanges();
            return quantity;
        } // Remove from Cart

        public List<ShoppingCartItem> GetCartItems()
        {
            var ShoppingCartItems = _dbContext.cartItems.Where(i => i.ShoppingCartId == ShoppingCartId).Include(i => i.Produit).ToList();
            return ShoppingCartItems;

        } // Get Cart Items

        public void ClearCart()
        {
            var cartItems = _dbContext.cartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
            _dbContext.cartItems.RemoveRange(cartItems);
            _dbContext.SaveChanges();
        } // Clear cart

        public decimal GetShoppingCartTotal()
        {

            var total = _dbContext.cartItems.Select(c => c.Produit.AskedPrice * c.Amount).Sum();
            return total;
        } // Total


        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProduitId = item.ShoppingCartItemID,
                    OrderId = order.OrderId,
                    UnitPrice = item.Produit.AskedPrice,
                    Quantity = item.Amount
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Amount * item.Produit.AskedPrice);

                _dbContext.orderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.OrderTotal = orderTotal;

            // Save the order
            _dbContext.SaveChanges();
            // Empty the shopping cart
            ClearCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }


    }// Class
}
