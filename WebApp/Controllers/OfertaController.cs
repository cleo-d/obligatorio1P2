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
		public IActionResult Create()
		{

			return View();
		}


		[HttpPost]
        public IActionResult Create(int Id, double Monto)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(Id);
            Usuario usuarioOferta = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));

            s.AltaOferta(usuarioOferta as Cliente, Monto);
            Oferta o = s.AltaOferta(usuarioOferta as Cliente, Monto);

            return RedirectToAction();
        }
    }
}
