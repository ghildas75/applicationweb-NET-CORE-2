using Projet.Models;
using System.Collections.Generic;

namespace Projet.Data.Interfaces
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> Produits { get;}
        IEnumerable<Produit> PopularProduit { get; }
        Produit GetProduitById(int produitId);
        IEnumerable<Produit> FindProductByDescription(string keyWord);
        void Add(Produit produit);
    }

   
}
