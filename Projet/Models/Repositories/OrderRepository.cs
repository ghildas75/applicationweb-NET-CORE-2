using Projet.Data;
using Projet.Interfaces;

namespace Projet.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateOrder(Order order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();

        }

        public ApplicationDbContext getContext() {

            return _context;
        }
    }
}
