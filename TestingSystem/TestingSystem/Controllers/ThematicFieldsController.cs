using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Models;

namespace TestingSystem.Controllers
{
    public class ThematicFieldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ThematicFields
        public ActionResult Index()
        {
            return View(db.ThematicFields.ToList());
        }

        // GET: ThematicFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicField thematicField = db.ThematicFields.Find(id);
            if (thematicField == null)
            {
                return HttpNotFound();
            }
            return View(thematicField);
        }

        // GET: ThematicFields/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThematicFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThematicFieldId,Name")] ThematicField thematicField)
        {
            if (ModelState.IsValid)
            {
                db.ThematicFields.Add(thematicField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thematicField);
        }

        // GET: ThematicFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicField thematicField = db.ThematicFields.Find(id);
            if (thematicField == null)
            {
                return HttpNotFound();
            }
            return View(thematicField);
        }

        // POST: ThematicFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThematicFieldId,Name")] ThematicField thematicField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thematicField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thematicField);
        }

        // GET: ThematicFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicField thematicField = db.ThematicFields.Find(id);
            if (thematicField == null)
            {
                return HttpNotFound();
            }
            return View(thematicField);
        }

        // POST: ThematicFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThematicField thematicField = db.ThematicFields.Find(id);
            db.ThematicFields.Remove(thematicField);
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
