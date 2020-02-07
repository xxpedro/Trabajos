using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabajosOnline.Models;
using System.IO;
using System.Web.Helpers;

namespace TrabajosOnline.Controllers
{
    public class UsuariosController : Controller
    {
        private TrabajosOnlineEntities db = new TrabajosOnlineEntities();

        // GET: Usuarios
        public ActionResult Index( )
        {
            /*Este es para listar los trabajos*/
            var trabajos = db.Trabajos.Include(t => t.Categoria_Trabajos).Include(t => t.Trabajos_habilidades).Take(10);
 
            return View(trabajos);
        }

        [HttpPost]
        public ActionResult Index(string buscar)
        {
            var Empleados = from cr in db.Trabajos select cr;

            if (!String.IsNullOrEmpty(buscar))
            {
                Empleados = Empleados.Where(c => c.Empesa.Contains(buscar));
            }

            return View(Empleados);

        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajos trabajos = db.Trabajos.Find(id);
            if (trabajos == null)
            {
                return HttpNotFound();
            }
            return View(trabajos);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "id,id_Usuario,Fecha_Aplicacion,id_Trabajo")] Aplicar_Trabajo aplicar_Trabajo, byte[] archivo, Usuario usuarios)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                archivo = ms.ToArray();
            }

            if (ModelState.IsValid)
            {

                aplicar_Trabajo.Fecha_Aplicacion = DateTime.Now;
                aplicar_Trabajo.doc = archivo;
                db.Aplicar_Trabajo.Add(aplicar_Trabajo);
                db.SaveChanges();
                
                
                return RedirectToAction("Index");

            }
            return View(aplicar_Trabajo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
