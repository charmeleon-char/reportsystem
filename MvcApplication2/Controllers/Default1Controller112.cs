using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class Default1Controller112 : Controller
    {
        private ReportSupEntities1 db = new ReportSupEntities1();

        //
        // GET: /Default1Controller112/

        public ActionResult Index()
        {
            return View(db.Checkinouts.ToList());
        }

        //
        // GET: /Default1Controller112/Details/5

        public ActionResult Details(int id = 0)
        {
            Checkinout checkinout = db.Checkinouts.Find(id);
            if (checkinout == null)
            {
                return HttpNotFound();
            }
            return View(checkinout);
        }

        //
        // GET: /Default1Controller112/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1Controller112/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Checkinout checkinout)
        {
            if (ModelState.IsValid)
            {
                db.Checkinouts.Add(checkinout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(checkinout);
        }

        //
        // GET: /Default1Controller112/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Checkinout checkinout = db.Checkinouts.Find(id);
            if (checkinout == null)
            {
                return HttpNotFound();
            }
            return View(checkinout);
        }

        //
        // POST: /Default1Controller112/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Checkinout checkinout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkinout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkinout);
        }

        //
        // GET: /Default1Controller112/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Checkinout checkinout = db.Checkinouts.Find(id);
            if (checkinout == null)
            {
                return HttpNotFound();
            }
            return View(checkinout);
        }

        //
        // POST: /Default1Controller112/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Checkinout checkinout = db.Checkinouts.Find(id);
            db.Checkinouts.Remove(checkinout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}