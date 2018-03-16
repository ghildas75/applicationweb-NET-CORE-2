using Microsoft.EntityFrameworkCore;
using Projet.Data;
using Projet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository

    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository( ApplicationDbContext contextDB)
        {
            _context = contextDB;
        }

        public IEnumerable<Category> Categories => throw new NotImplementedException();

        public Category getCategoryById(int Id)
        {
            return _context.categories.Include("Produits").SingleOrDefault(c => c.CategoryId == Id);
        }

        public Category getCategoryByName(string Name)
        {
            return _context.categories.Include("Produits").SingleOrDefault(c => c.CategoryName == Name);
        }
    }
}
