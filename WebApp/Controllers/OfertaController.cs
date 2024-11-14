using Clases;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class OfertaController : Controller
    {
        Sistema s = Sistema.Instancia();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int id, double monto)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
            Usuario usuarioOferta = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));

            return RedirectToAction("Index","PublicacionController");
        }
    }
}
