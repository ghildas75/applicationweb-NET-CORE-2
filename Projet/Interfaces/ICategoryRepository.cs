using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        Category getCategoryByName(string name);
        Category getCategoryById(int id);
    }
}
