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
            string nombreUsuarioLogeado = HttpContext.Session.GetString("nombreLogeado");
            ViewBag.MsgInicio = nombreUsuarioLogeado;
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasenia)
        {
            try
            {
                Usuario uBuscado = s.Login(email, contrasenia);

                if (uBuscado != null) 
                { 
                    //Guardo el id
                    HttpContext.Session.SetInt32("idLogeado", uBuscado.Id);
                    // Guardo el rol
                    HttpContext.Session.SetString("rolLogeado", uBuscado.Rol);
                    // Guardo el nombre
                    HttpContext.Session.SetString("nombreLogeado", uBuscado.Nombre);

					return RedirectToAction("Index");
				}
                else
                {
					ViewBag.Msg = "Usuario no encontrado, intente nuevamente";
				}

				
			}
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
