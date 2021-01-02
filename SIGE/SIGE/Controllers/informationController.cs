using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIGE.Models;

namespace SIGE.Controllers
{
    public class informationController : Controller
    {
        private usersEntities db = new usersEntities();

        // GET: information
        public async Task<ActionResult> Index()
        {
            return View(await db.information.ToListAsync());
        }

        // GET: information/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            information information = await db.information.FindAsync(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // GET: information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: information/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,usuario,identificacion,nombres,apellidos,contrasena,direccion,fechaNacimiento,celular,email")] information information)
        {
            if (ModelState.IsValid)
            {
                db.information.Add(information);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(information);
        }

        // GET: information/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            information information = await db.information.FindAsync(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // POST: information/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,usuario,identificacion,nombres,apellidos,contrasena,direccion,fechaNacimiento,celular,email")] information information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(information).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(information);
        }

        // GET: information/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            information information = await db.information.FindAsync(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // POST: information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            information information = await db.information.FindAsync(id);
            db.information.Remove(information);
            await db.SaveChangesAsync();
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
