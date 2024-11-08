using Clases;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.Instancia();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }

    }
}
