
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Projet.ViewModels;
using Projet.Models.Repositories;
using Projet.Models;
using System.Collections.Generic;
using Projet.Models.ShoppingCart;
using Projet.Data.Interfaces;

namespace Projet.Controllers
{
    [Authorize(Roles = "Gestionnaire, Gerant")]
    public class GestionnaireController : Controller


    {
        public IActionResult Index()
        {
            return View();
        }
    }
}