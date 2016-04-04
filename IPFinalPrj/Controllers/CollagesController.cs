using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IPFinalPrj.Models;

namespace IPFinalPrj.Controllers
{
    [Authorize]
    public class CollagesController : Controller
    {
        private IPFinalPrjContext db = new IPFinalPrjContext();

        // GET: Collages
        public ActionResult Index()
        {
            return View(db.Collages.ToList());
        }

        public ActionResult SlideShowGen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collage collage = db.Collages.Find(id);
            if (collage == null)
            {
                return HttpNotFound();
            }
            return View(collage.storyblock);
        }

        // GET: Collages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collage collage = db.Collages.Find(id);
            if (collage == null)
            {
                return HttpNotFound();
            }
            return View(collage);
        }

        // GET: Collages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollageID,CollageSeq,CollageName,Author,Status,CollageTime,Uploaded,ExtraStringCollage,ExtraIntCollage,ExtraStringCollage1,ExtraIntCollage1")] Collage collage)
        {
            if (ModelState.IsValid)
            {
                db.Collages.Add(collage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collage);
        }

        // GET: Collages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collage collage = db.Collages.Find(id);
            if (collage == null)
            {
                return HttpNotFound();
            }
            return View(collage);
        }

        // POST: Collages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollageID,CollageSeq,CollageName,Author,Status,CollageTime,Uploaded,ExtraStringCollage,ExtraIntCollage,ExtraStringCollage1,ExtraIntCollage1")] Collage collage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collage);
        }

        // GET: Collages/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collage collage = db.Collages.Find(id);
            if (collage == null)
            {
                return HttpNotFound();
            }
            return View(collage);
        }

        // POST: Collages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collage collage = db.Collages.Find(id);
            db.Collages.Remove(collage);
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
