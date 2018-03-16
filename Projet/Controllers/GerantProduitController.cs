using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet.Data;
using Projet.Models;
using Microsoft.AspNetCore.Authorization;

namespace Projet_Final.Controllers
{
    [Authorize(Roles = "Gerant")]
    public class GerantProduitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerantProduitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GerantProduit
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.produits.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GerantProduit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.produits
                .Include(p => p.Category)
                .SingleOrDefaultAsync(m => m.ProduitId == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: GerantProduit/Create
        public IActionResult Create()
        {
            ViewData["CategoryName"] = new SelectList(_context.categories, "CategoryName", "CategoryName");
            return View();
        }

        // POST: GerantProduit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduitId,Name,AskedPrice,SalePrice,ShortDescription,LongDescription,Weight,ImageUrl,isPopular,InStock,Quantite,CategoryId")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", produit.CategoryId);
            return View(produit);
        }

        // GET: GerantProduit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.produits.SingleOrDefaultAsync(m => m.ProduitId == id);
            if (produit == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", produit.CategoryId);
            return View(produit);
        }

        // POST: GerantProduit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduitId,Name,AskedPrice,SalePrice,ShortDescription,LongDescription,Weight,ImageUrl,isPopular,InStock,Quantite,CategoryId")] Produit produit)
        {
            if (id != produit.ProduitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.ProduitId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", produit.CategoryId);
            return View(produit);
        }

        // GET: GerantProduit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.produits
                .Include(p => p.Category)
                .SingleOrDefaultAsync(m => m.ProduitId == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: GerantProduit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produit = await _context.produits.SingleOrDefaultAsync(m => m.ProduitId == id);
            _context.produits.Remove(produit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitExists(int id)
        {
            return _context.produits.Any(e => e.ProduitId == id);
        }
    }
}
