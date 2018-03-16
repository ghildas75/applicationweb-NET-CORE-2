using Projet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> FindAllClients(int userId);
        Client FindClientByEmail(string email);
        Client FindClientById(int userId, int clientId);
        void ClientInsert(Client client);
        int updateClient(Client clientBO);
        bool deleteClients(string Ids, int userId);
        void SaveChanges();
    }
}
