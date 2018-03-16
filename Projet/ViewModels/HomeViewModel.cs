using Projet.Models;
using System.Collections.Generic;

namespace Projet.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produit> PopularProduit { get; set; }
    }
}
