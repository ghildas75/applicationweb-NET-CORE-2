using Projet.Data;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Interfaces
{
    public interface IOrderRepository
    {

        void CreateOrder(Order order);
        ApplicationDbContext getContext();
    }
}
