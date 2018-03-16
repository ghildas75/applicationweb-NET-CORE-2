using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    public class ShoppingCartItem
    {
        // [BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingCartItemID { get; set; }
        public Produit Produit { get; set; }
        public bool CartStatus { get; set; }
        //The Quantity the user wants to order
        public int Amount { get; set; }
        public DateTime DateAjout { get; set; } 
        //The link to shopingcart
        public string ShoppingCartId { get; set; }
    }
}
