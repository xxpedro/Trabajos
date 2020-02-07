using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajosOnline.Models;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Data.Entity;

namespace TrabajosOnline.Controllers
{
    public class AccesoController : Controller
    {
        TrabajosOnlineEntities db = new TrabajosOnlineEntities();

        // GET: Acceso
        [HttpGet]
        public ActionResult Login()
        {
            var lista = from d in db.Trabajos
                        orderby d.fecha_Publicacion
                        select d;

            var trabajos = db.Trabajos.Include(t => t.Categoria_Trabajos).Include(t => t.Trabajos_habilidades);

            return View(lista.Take(3));
        }

        [HttpPost]
        public ActionResult Login(string correo, string contrasena, Usuario us)
        {

            if (ModelState.IsValid)
            {
                if (db.Usuario.Where(m => m.Correo == correo && m.Contraseña == contrasena && m.Rol == "admin").Count()>0)
                {
                  
                    Session["Nombre"] = correo;
                    return RedirectToAction("Index", "Administrador");

                }
                else if (db.Usuario.Where(m => m.Correo == correo && m.Contraseña == contrasena && m.Rol == "user").Count()>0)
                {
                    Session["correo"] = correo;
                    return RedirectToAction("Index", "Usuarios");
                }
                else
                {
                    return View("Login");
                }
            }
            return View();
        }
    

        [HttpGet]
        public ActionResult Registrar()
        {


            return View();
        }



        [HttpPost]
        public ActionResult Registrar(Usuario usu, string correo)
        {

            if (ModelState.IsValid)
            {
                if (db.Usuario.Where(m => m.Correo == correo).Count() > 0)
                {
                    ViewBag.Error = "Esta cuenta ya existe, Intente con otra";
                    return View();

                }
                else
                {
                    using (TrabajosOnlineEntities db = new TrabajosOnlineEntities())
                    {
                        usu.Rol = "user";
                       

                        db.Usuario.Add(usu);
                        db.SaveChanges();
                    }

                }
            }
            return View();
        }


















        public ActionResult Home()
        {
            return View();
        }





    }
}