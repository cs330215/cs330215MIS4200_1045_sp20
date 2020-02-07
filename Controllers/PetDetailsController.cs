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
            var petDetails = db.petDetails.Include(p => p.Owners).Include(p => p.Pets);
            return View(petDetails.ToList());
        }

        // GET: PetDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetDetails petDetails = db.petDetails.Find(id);
            if (petDetails == null)
            {
                return HttpNotFound();
            }
            return View(petDetails);
        }

        // GET: PetDetails/Create
        public ActionResult Create()
        {
            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "Full Name");
            ViewBag.petID = new SelectList(db.Pets, "petID", "Pet Name");
            return View();
        }

        // POST: PetDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "petdetailID,petOwnerID,ownerID,petID")] PetDetails petDetails)
        {
            if (ModelState.IsValid)
            {
                db.petDetails.Add(petDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "ownerFirstName", petDetails.ownerID);
            ViewBag.petID = new SelectList(db.Pets, "petID", "petName", petDetails.petID);
            return View(petDetails);
        }

        // GET: PetDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetDetails petDetails = db.petDetails.Find(id);
            if (petDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "ownerFirstName", petDetails.ownerID);
            ViewBag.petID = new SelectList(db.Pets, "petID", "petName", petDetails.petID);
            return View(petDetails);
        }

        // POST: PetDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "petdetailID,petOwnerID,ownerID,petID")] PetDetails petDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ownerID = new SelectList(db.Owners, "ownerID", "ownerFirstName", petDetails.ownerID);
            ViewBag.petID = new SelectList(db.Pets, "petID", "petName", petDetails.petID);
            return View(petDetails);
        }

        // GET: PetDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetDetails petDetails = db.petDetails.Find(id);
            if (petDetails == null)
            {
                return HttpNotFound();
            }
            return View(petDetails);
        }

        // POST: PetDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetDetails petDetails = db.petDetails.Find(id);
            db.petDetails.Remove(petDetails);
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
