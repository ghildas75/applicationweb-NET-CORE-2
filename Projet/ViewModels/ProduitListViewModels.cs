using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projet.Models;

namespace Projet.ViewModels
{
    public class ProduitListViewModels
    {
        public  virtual IEnumerable<Produit> Produits { get; set; }
        public String CurrentCategory;
    }
}
