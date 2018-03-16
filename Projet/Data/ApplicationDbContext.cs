using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet.Models;
using Projet.Models.Entities;

namespace Projet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<ShoppingCartItem> cartItems { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Produit> produits { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Entreprise> Entreprise { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
