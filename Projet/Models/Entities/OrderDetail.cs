using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    public class OrderDetail
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProduitId { get; set; }
        public int Quantity { get; set; } //
        public decimal UnitPrice { get; set; } //
        public virtual Produit Produit { get; set; }
        public virtual Order Order { get; set; }
    }
}
