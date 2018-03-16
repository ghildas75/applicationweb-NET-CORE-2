using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Models
{
    public class Produit
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProduitId { get; set; }
        public string Name { get; set; }
        public decimal AskedPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Weight { get; set; }
        public string ImageUrl { get; set; }
        public bool isPopular { get; set; }
        public bool InStock { get; set; }
        public int Quantite { get; set; } // quantite dans le stock
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

   
}
