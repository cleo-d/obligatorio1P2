using Clases;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Detalles(int id)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
           
            return View(publicacionEncontrada);
        }

        
        public IActionResult Comprar(int id)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);
            Usuario usuarioCierrePublicacion = s.GetUsuarioPorId(HttpContext.Session.GetInt32("idLogeado"));

            try
            {
                publicacionEncontrada.CerrarPublicacion(usuarioCierrePublicacion, publicacionEncontrada.PrecioPublicacion);
            }
            catch (Exception e)
            {

                ViewBag.Msg = e.Message;
                return View();
            }
            

            return RedirectToAction("Index");
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
