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
    public class InterestRateTypesController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: InterestRateTypes
        public ActionResult Index()
        {
            return View(db.InterestRateTypes.ToList());
        }

        // GET: InterestRateTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestRateType interestRateType = db.InterestRateTypes.Find(id);
            if (interestRateType == null)
            {
                return HttpNotFound();
            }
            return View(interestRateType);
        }

        // GET: InterestRateTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterestRateTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RateTypeID,RateTypeName")] InterestRateType interestRateType)
        {
            if (ModelState.IsValid)
            {
                db.InterestRateTypes.Add(interestRateType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interestRateType);
        }

        // GET: InterestRateTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestRateType interestRateType = db.InterestRateTypes.Find(id);
            if (interestRateType == null)
            {
                return HttpNotFound();
            }
            return View(interestRateType);
        }

        // POST: InterestRateTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RateTypeID,RateTypeName")] InterestRateType interestRateType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interestRateType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interestRateType);
        }

        // GET: InterestRateTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestRateType interestRateType = db.InterestRateTypes.Find(id);
            if (interestRateType == null)
            {
                return HttpNotFound();
            }
            return View(interestRateType);
        }

        // POST: InterestRateTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterestRateType interestRateType = db.InterestRateTypes.Find(id);
            db.InterestRateTypes.Remove(interestRateType);
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
