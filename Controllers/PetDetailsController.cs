using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cs330215MIS4200_1045_sp20.DAL;
using cs330215MIS4200_1045_sp20.Models;

namespace cs330215MIS4200_1045_sp20.Controllers
{
    public class PetDetailsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: PetDetails
        public ActionResult Index()
        {
            var petDetails = db.PetDetails.Include(p => p.Owners).Include(p => p.Pets);
            return View(petDetails.ToList());
        }

        // GET: PetDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetDetails petDetails = db.PetDetails.Find(id);
            if (petDetails == null)
            {
                return HttpNotFound();
            }
            return View(petDetails);
        }

        // GET: PetDetails/Create
        public ActionResult Create()
        {
            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "fullName");
            ViewBag.petID = new SelectList(db.Pets, "petID", "petName");
            return View();
        }

        // POST: PetDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "petOwnerID,ownerID,petID")] PetDetails PetDetails)
        {
            if (ModelState.IsValid)
            {
                db.PetDetails.Add(PetDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "fullName", PetDetails.ownerID);
            ViewBag.petID = new SelectList(db.Pets, "petID", "petName", PetDetails.petID);
            return View(PetDetails);
        }

        // GET: PetDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetDetails PetDetails = db.PetDetails.Find(id);
            if (PetDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "fullName", PetDetails.ownerID);
            ViewBag.petID = new SelectList(db.Pets, "petID", "petName", PetDetails.petID);
            return View(PetDetails);
        }

        // POST: PetDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "petOwnerID,ownerID,petID")] PetDetails PetDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(PetDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "fullName", PetDetails.ownerID);
            ViewBag.petID = new SelectList(db.Pets, "petID", "petName", PetDetails.petID);
            return View(PetDetails);
        }

        // GET: PetDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetDetails PetDetails = db.PetDetails.Find(id);
            if (PetDetails == null)
            {
                return HttpNotFound();
            }
            return View(PetDetails);
        }

        // POST: PetDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetDetails PetDetails = db.PetDetails.Find(id);
            db.PetDetails.Remove(PetDetails);
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
