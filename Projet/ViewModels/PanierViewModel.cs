using Projet.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.ViewModels
{
    public class PanierViewModel
    {

        public ShoppingCart ShoppingCart { get; set; }
        public decimal Total { get; set; }

    }
}
