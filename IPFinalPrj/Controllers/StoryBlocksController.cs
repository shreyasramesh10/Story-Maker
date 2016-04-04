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
    public class StoryBlocksController : Controller
    {
        private IPFinalPrjContext db = new IPFinalPrjContext();

        // GET: StoryBlocks
        public ActionResult Index()
        {
            var storyBlocks = db.StoryBlocks.Include(s => s.collage);
            return View(storyBlocks.ToList());
        }

        // GET: StoryBlocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryBlock storyBlock = db.StoryBlocks.Find(id);
            if (storyBlock == null)
            {
                return HttpNotFound();
            }
            return View(storyBlock);
        }

        // GET: StoryBlocks/Create
        public ActionResult Create()
        {
            ViewBag.CollageID = new SelectList(db.Collages, "CollageID", "CollageName");
            return View();
        }

        // POST: StoryBlocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoryBlockID,StoryBlockSeq,Caption,Description,ImgName,ImgPath,Status,ExtraStringSb,ExtraIntSb,ExtraStringSb1,ExtraIntSb1,CollageID")] StoryBlock storyBlock)
        {
            if (ModelState.IsValid)
            {
                db.StoryBlocks.Add(storyBlock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CollageID = new SelectList(db.Collages, "CollageID", "CollageName", storyBlock.CollageID);
            return View(storyBlock);
        }

        // GET: StoryBlocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryBlock storyBlock = db.StoryBlocks.Find(id);
            if (storyBlock == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollageID = new SelectList(db.Collages, "CollageID", "CollageName", storyBlock.CollageID);
            return View(storyBlock);
        }

        // POST: StoryBlocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoryBlockID,StoryBlockSeq,Caption,Description,ImgName,ImgPath,Status,ExtraStringSb,ExtraIntSb,ExtraStringSb1,ExtraIntSb1,CollageID")] StoryBlock storyBlock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storyBlock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollageID = new SelectList(db.Collages, "CollageID", "CollageName", storyBlock.CollageID);
            return View(storyBlock);
        }

        // GET: StoryBlocks/Delete/5
        [Authorize(Roles="admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryBlock storyBlock = db.StoryBlocks.Find(id);
            if (storyBlock == null)
            {
                return HttpNotFound();
            }
            return View(storyBlock);
        }

        // POST: StoryBlocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoryBlock storyBlock = db.StoryBlocks.Find(id);
            db.StoryBlocks.Remove(storyBlock);
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
