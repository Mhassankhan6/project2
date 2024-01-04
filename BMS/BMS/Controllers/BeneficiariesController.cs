using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BMS.Models;

namespace BMS.Controllers
{
    public class BeneficiariesController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: Beneficiaries
        public ActionResult Index()
        {
            var beneficiaries = db.Beneficiaries.Include(b => b.User);
            return View(beneficiaries.ToList());
        }

        // GET: Beneficiaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficiary beneficiary = db.Beneficiaries.Find(id);
            if (beneficiary == null)
            {
                return HttpNotFound();
            }
            return View(beneficiary);
        }

        // GET: Beneficiaries/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Beneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BeneficiaryID,BeneficiaryName,AccountNumber,AccountType,Description,UserID")] Beneficiary beneficiary)
        {
            if (ModelState.IsValid)
            {
                db.Beneficiaries.Add(beneficiary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", beneficiary.UserID);
            return View(beneficiary);
        }

        // GET: Beneficiaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficiary beneficiary = db.Beneficiaries.Find(id);
            if (beneficiary == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", beneficiary.UserID);
            return View(beneficiary);
        }

        // POST: Beneficiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BeneficiaryID,BeneficiaryName,AccountNumber,AccountType,Description,UserID")] Beneficiary beneficiary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beneficiary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", beneficiary.UserID);
            return View(beneficiary);
        }

        // GET: Beneficiaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficiary beneficiary = db.Beneficiaries.Find(id);
            if (beneficiary == null)
            {
                return HttpNotFound();
            }
            return View(beneficiary);
        }

        // POST: Beneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beneficiary beneficiary = db.Beneficiaries.Find(id);
            db.Beneficiaries.Remove(beneficiary);
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
