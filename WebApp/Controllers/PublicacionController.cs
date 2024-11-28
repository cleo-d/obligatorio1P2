using Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema s = Sistema.Instancia();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("idLogeado") != null)
            {
                IEnumerable<Publicacion> publicaciones = s.GetPublicaciones(); 

                return View(publicaciones);
            }
            else
            {
				return RedirectToAction("Index", "Home");
			}
            }

            public IActionResult Detalles(int id, string? mensaje)
            {
            if (HttpContext.Session.GetInt32("idLogeado") != null)
            {
                Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);


                if (mensaje != null)
                {
                    ViewBag.Error = mensaje;

                }
                return View(publicacionEncontrada);
            }
            else
            {
				return RedirectToAction("Index", "Home");
			}
            }


            public IActionResult Comprar(int id)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
            Usuario usuarioCierrePublicacion = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));

            try
            {
              
                publicacionEncontrada.CerrarPublicacion(usuarioCierrePublicacion, publicacionEncontrada.PrecioPublicacion);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

               
                return RedirectToAction("Detalles", new { id = id, mensaje = e.Message });
            }
            

            
        }
        
        [HttpPost]
        public IActionResult Detalles(int id, double Monto)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
            Usuario usuarioOferta = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));
            //s.AgregarOfertaAPublicacion(id, usuarioOferta, monto);

            return RedirectToAction("Index");

        }


    }
}
