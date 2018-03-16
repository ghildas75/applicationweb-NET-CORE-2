using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Entities
{
    public  class Entreprise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int entrepriseID { get; set; }
        public   double TPS { get; set; }
        public double TVQ { get; set; }
        public  decimal LivraisonGratuite { get; set; }
        public  string NomVendeur { get; set; }
        public  bool Taxes { get; set; }
    }
}
