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

            Oferta o = s.AltaOferta(usuarioOferta as Cliente, Monto);

            //Agrego la oferta nueva a la lista de ofertas de la subasta
            (publicacionEncontrada as Subasta).AgregarOferta(o);

            return RedirectToAction();
        }
    }
}
