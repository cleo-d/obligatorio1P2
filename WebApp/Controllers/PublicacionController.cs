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
            IEnumerable<Publicacion> publicaciones = s.GetPublicaciones();
            //puedo ya mandar las publicaciones ordenadas por fecha y q queden todas ordenadas 
            
            return View(publicaciones);
        }

        public IActionResult Detalles(int id, string? mensaje)
        {
            Publicacion publicacionEncontrada = s.GetPublicacionPorId(id);


            if (mensaje != null)
            {
            ViewBag.Error = mensaje;

            } 

            

            return View(publicacionEncontrada);
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

                ViewBag.Msg = e.Message;
                return RedirectToAction("Detalles", new { id = id });
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
