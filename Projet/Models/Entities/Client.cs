using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Entities
{
    public class Client
    {
        //[Display(Name = "Customer number")]
        [BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int clientID { get; set; }
        //PAGE 11 DU PROJET
        //nbre de fois le client s y connecter
        public int ConnexionNumber { get; set; }
        //date de creation Nombre de nouveaux clients depuis 3, 6, 9 et 12 mois
        public DateTime CreateDate { get; set; }
        public DateTime LastConnected { get; set; }
        public string CreatedBy { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //public int OrderID { get; set; }
        public List<Order> order { get; set; }
        

    }
}
