using Clases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema s = Sistema.Instancia();

        public IActionResult Index()
        {
            IEnumerable<Publicacion> publicaciones = s.GetPublicaciones();
            
            return View(publicaciones);
        }

        public IActionResult Comprar(int id)
        {
            Publicacion publicacionEncontrada = s.GetArticuloPorId(id);

            return View(publicacionEncontrada);
        }

      
    }
}
