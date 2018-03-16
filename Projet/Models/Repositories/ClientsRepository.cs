using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projet.Data.Interfaces;
using Projet.Models;
using Projet.Data;
using Projet.Interfaces;
using Projet.Models.Entities;

namespace Projet.Models.Repositories
{
    public class ClientsRepository : IClientRepository

    {
        private readonly ApplicationDbContext _context;

        public ClientsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produit> Produits => _context.produits.Include(c => c.Category);

        public IEnumerable<Produit> PopularProduit => _context.produits.Where(p => p.isPopular).Include(c => c.Category);

        public void ClientInsert(Client client)
        {
            _context.clients.Add(client);
            _context.SaveChanges();
        }

        public Client FindClientByEmail(string email)
        {

            var client = _context.clients.SingleOrDefault(c => c.Email == email);
            return client;

        }

        public bool deleteClients(string Ids, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> FindAllClients(int userId)
        {
            throw new NotImplementedException();
        }

        public Client FindClientById(int userId, int clientId)
        {
            throw new NotImplementedException();
        }

        public Produit GetProduitById(int produitId) => _context.produits.Find(produitId);

        public int updateClient(Client clientPr)
        {
            var client = _context.clients.SingleOrDefault(c => c.Email == clientPr.Email);
            _context.Set<Client>().Attach(clientPr);
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
            return 1;

        }

        public void  SaveChanges()
        {
            
            _context.SaveChanges();
            

        }
    }
}
