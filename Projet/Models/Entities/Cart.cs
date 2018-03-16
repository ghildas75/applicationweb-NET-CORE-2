using System.Collections.Generic;

namespace Projet.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems;
    }
}
