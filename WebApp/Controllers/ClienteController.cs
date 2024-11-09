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
    }
    
}
