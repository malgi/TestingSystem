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
    public class TestSchemesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestSchemes
        public ActionResult Index()
        {
            return View(db.TestSchemes.ToList());
        }

        // GET: TestSchemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestScheme testScheme = db.TestSchemes.Find(id);
            if (testScheme == null)
            {
                return HttpNotFound();
            }
            return View(testScheme);
        }

        // GET: TestSchemes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestSchemes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestSchemeId,Name,Time,AvailableFrom,AvailableTo,NumberOfQuestions")] TestScheme testScheme)
        {
            if (ModelState.IsValid)
            {
                db.TestSchemes.Add(testScheme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testScheme);
        }

        // GET: TestSchemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestScheme testScheme = db.TestSchemes.Find(id);
            if (testScheme == null)
            {
                return HttpNotFound();
            }
            return View(testScheme);
        }

        // POST: TestSchemes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestSchemeId,Name,Time,AvailableFrom,AvailableTo,NumberOfQuestions")] TestScheme testScheme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testScheme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testScheme);
        }

        // GET: TestSchemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestScheme testScheme = db.TestSchemes.Find(id);
            if (testScheme == null)
            {
                return HttpNotFound();
            }
            return View(testScheme);
        }

        // POST: TestSchemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestScheme testScheme = db.TestSchemes.Find(id);
            db.TestSchemes.Remove(testScheme);
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
