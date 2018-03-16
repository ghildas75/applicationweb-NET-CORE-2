using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet.Data;
using Projet.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Projet_Final.Controllers
{
    [Authorize(Roles = "Gerant")]
    public class GerantClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerantClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GerantClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.clients.ToListAsync());
        }

        // GET: GerantClients/Details/5
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

        
        // GET: GerantClients/Edit/5
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

        // POST: GerantClients/Edit/5
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

        // GET: GerantClients/Delete/5
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

        // POST: GerantClients/Delete/5
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
