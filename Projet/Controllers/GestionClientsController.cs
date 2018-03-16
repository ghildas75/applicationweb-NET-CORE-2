using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet.Data;
using Projet.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Projet.Controllers
{
    [Authorize(Roles = "Gestionnaire")]
    public class GestionClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestionClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GestionClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.clients.ToListAsync());
        }

        // GET: GestionClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.clients
                .SingleOrDefaultAsync(m => m.clientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: GestionClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.clients.SingleOrDefaultAsync(m => m.clientID == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: GestionClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("clientID,ConnexionNumber,CreateDate,LastConnected,CreatedBy,FirstName,LastName,Address,City,Province,PostalCode,Country,PhoneNumber,Email")] Client client)
        {
            if (id != client.clientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.clientID))
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
            return View(client);
        }

        // GET: GestionClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.clients
                .SingleOrDefaultAsync(m => m.clientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: GestionClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.clients.SingleOrDefaultAsync(m => m.clientID == id);
            _context.clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.clients.Any(e => e.clientID == id);
        }
    }
}
