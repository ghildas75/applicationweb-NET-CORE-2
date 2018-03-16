using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projet.Data.Interfaces;
using Projet.Models;
using Projet.Data;

namespace Projet.Models.Repositories
{
    public class ProductRepository : IProduitRepository

    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produit> Produits => _context.produits.Include(c=>c.Category);

        public IEnumerable<Produit> PopularProduit => _context.produits.Where(p=>p.isPopular).Include(c=>c.Category);

        public Produit GetProduitById(int produitId) => _context.produits.Find(produitId);

        public IEnumerable<Produit> FindProductByDescription(string keyWord)
       => _context.produits.Where(p => p.ShortDescription.Contains(keyWord));

        public void Add(Produit produit)
        {
            _context.Add(produit);
            _context.SaveChanges();
        }
    }
}
