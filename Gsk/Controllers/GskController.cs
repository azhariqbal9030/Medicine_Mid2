using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gsk.Data;
using Gsk.Models;

namespace Gsk.Controllers
{
    public class GskController : Controller
    {
        private GskContext db = new GskContext();

        // GET: Gsk
        public ActionResult Index(string searchString)
        {
            var gsk = from m in db.GskModels
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                gsk = gsk.Where(s => s.Name.Contains(searchString));
            }

            return View(gsk);
        }

        // GET: Gsk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GskModel gskModel = db.GskModels.Find(id);
            if (gskModel == null)
            {
                return HttpNotFound();
            }
            return View(gskModel);
        }

        // GET: Gsk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gsk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,IssueDate,ExpiryDate,Price")] GskModel gskModel)
        {
            if (ModelState.IsValid)
            {
                db.GskModels.Add(gskModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gskModel);
        }

        // GET: Gsk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GskModel gskModel = db.GskModels.Find(id);
            if (gskModel == null)
            {
                return HttpNotFound();
            }
            return View(gskModel);
        }

        // POST: Gsk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IssueDate,ExpiryDate,Price")] GskModel gskModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gskModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gskModel);
        }

        // GET: Gsk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GskModel gskModel = db.GskModels.Find(id);
            if (gskModel == null)
            {
                return HttpNotFound();
            }
            return View(gskModel);
        }

        // POST: Gsk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GskModel gskModel = db.GskModels.Find(id);
            db.GskModels.Remove(gskModel);
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
