using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}