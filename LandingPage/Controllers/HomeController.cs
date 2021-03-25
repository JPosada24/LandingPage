using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LandingPage.Models;

namespace LandingPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            DatosUsuarios du = new DatosUsuarios();
            Usuario usu = new Usuario
            {
                Nombre = collection["nombre"],
                Apellido = collection["apellido"],
                Email = collection["email"],
                Telefono = long.Parse(collection["telefono"].ToString()),
                Edad = int.Parse(collection["edad"].ToString())
            };

            du.AgregarUsuario(usu);
            return RedirectToAction("Mensaje");
        }

        public ActionResult ConsultarTodo()
        {
            DatosUsuarios da = new DatosUsuarios();
            return View(da.RecuperarUsuarios());
        }

        public ActionResult Mensaje()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            DatosUsuarios du = new DatosUsuarios();
            Usuario usu = du.RecuperarId(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DatosUsuarios du = new DatosUsuarios();
            du.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}