using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProgIII.Models;
using System.IO;

namespace FinalProgIII.Controllers
{
    public class ProductosController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Proveedor);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.ProveedorID = new SelectList(db.Proveedor, "ProveedorID", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoID,ProveedorID,Nombre,Precio,Disponibilidad,FotoPROD")] Producto producto
            , HttpPostedFileBase FotoPROD)
        {
            if (FotoPROD != null && FotoPROD.ContentLength > 0)
            {
                var image = Path.GetFileName(FotoPROD.FileName);
                var path = Path.Combine(Server.MapPath("~/Imagenes"), image);
                var path2 = "~" + "/Imagenes" + image;

                FotoPROD.SaveAs(path);
                producto.FotoPROD = path2;

                return RedirectToAction("Index");

            }

            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProveedorID = new SelectList(db.Proveedor, "ProveedorID", "Nombre", producto.ProveedorID);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProveedorID = new SelectList(db.Proveedor, "ProveedorID", "Nombre", producto.ProveedorID);
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoID,ProveedorID,Nombre,Precio,Disponibilidad,FotoPROD")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedorID = new SelectList(db.Proveedor, "ProveedorID", "Nombre", producto.ProveedorID);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
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
