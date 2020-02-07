using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabajosOnline.Models;

namespace TrabajosOnline.Controllers
{
    public class AdministradorController : Controller
    {
        private TrabajosOnlineEntities db = new TrabajosOnlineEntities();

        // GET: Administrador
        public ActionResult Index()
        {
            var trabajos = db.Trabajos.Include(t => t.Categoria_Trabajos).Include(t => t.Trabajos_habilidades);
            return View(trabajos.ToList());
        }

        // GET: Administrador/Details/5
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

 
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.Categoria_Trabajos, "id", "Nombre");
            ViewBag.id_Habilidades = new SelectList(db.Trabajos_habilidades, "id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_Habilidades,Descripcion,sueldo,Direccion,fecha_Publicacion,condiciones,Estado,id_categoria,Empesa,Beneficios,Credenciales")] Trabajos trabajos)
        {

            trabajos.fecha_Publicacion = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Trabajos.Add(trabajos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.Categoria_Trabajos, "id", "Nombre", trabajos.id_categoria);
            ViewBag.id_Habilidades = new SelectList(db.Trabajos_habilidades, "id", "Nombre", trabajos.id_Habilidades);
            return View(trabajos);
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.id_categoria = new SelectList(db.Categoria_Trabajos, "id", "Nombre", trabajos.id_categoria);
            ViewBag.id_Habilidades = new SelectList(db.Trabajos_habilidades, "id", "Nombre", trabajos.id_Habilidades);
            return View(trabajos);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_Habilidades,Descripcion,sueldo,Direccion,fecha_Publicacion,condiciones,Estado,id_categoria,Empesa,Beneficios,Credenciales")] Trabajos trabajos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.Categoria_Trabajos, "id", "Nombre", trabajos.id_categoria);
            ViewBag.id_Habilidades = new SelectList(db.Trabajos_habilidades, "id", "Nombre", trabajos.id_Habilidades);
            return View(trabajos);
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajos trabajos = db.Trabajos.Find(id);
            db.Trabajos.Remove(trabajos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
