using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NomipaqSync.Models;

namespace NomipaqSync.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Nomipaq Utilies.";

            return View();
        }

        public IActionResult NomipaqUtilities()
        {
            ViewData["Message"] = "Utilerias para Nomipaq (Nomina Maniobras)";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Transmaquila.com";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
