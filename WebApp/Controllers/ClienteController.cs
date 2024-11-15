using Clases;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
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
        public IActionResult Create(Cliente c)
        {
            try
            {
                s.AltaCliente(c);
                ViewBag.Msg = "Cliente creado con exito";
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }

            return View();
        }

        public IActionResult CargarSaldo()
        {
            Usuario u = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));

            return View(u);
        }

        [HttpPost]
		public IActionResult CargarSaldo(Double saldo)
		{
			Usuario u = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));

            s.CargarSaldoUsuario(u, saldo);
			return View(u);
		}
	}
    
}
