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

namespace Projet.Controllers
{
    [Authorize(Roles = "Gerant")]
    public class GerantCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerantCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GerantCarts
        public async Task<IActionResult> Index()
        {
            return View(await _context.cartItems.Include(c => c.Produit).ThenInclude(p => p.Category).ToListAsync());
        }

        // GET: GerantCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCartItem = await _context.cartItems.Include(c=>c.Produit).ThenInclude(p => p.Category)
                .SingleOrDefaultAsync(m => m.ShoppingCartItemID == id);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return View(shoppingCartItem);
        }

        

        // GET: GerantCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCartItem = await _context.cartItems.Include(c => c.Produit).ThenInclude(p => p.Category)
                .SingleOrDefaultAsync(m => m.ShoppingCartItemID == id);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return View(shoppingCartItem);
        }

        // POST: GerantCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingCartItem = await _context.cartItems.Include(c => c.Produit).ThenInclude(p=>p.Category).SingleOrDefaultAsync(m => m.ShoppingCartItemID == id);
            _context.cartItems.Remove(shoppingCartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartItemExists(int id)
        {
            return _context.cartItems.Any(e => e.ShoppingCartItemID == id);
        }
    }
}
