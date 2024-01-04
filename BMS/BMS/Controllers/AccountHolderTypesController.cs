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
    public class AccountHolderTypesController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: AccountHolderTypes
        public ActionResult Index()
        {
            return View(db.AccountHolderTypes.ToList());
        }

        // GET: AccountHolderTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolderType accountHolderType = db.AccountHolderTypes.Find(id);
            if (accountHolderType == null)
            {
                return HttpNotFound();
            }
            return View(accountHolderType);
        }

        // GET: AccountHolderTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountHolderTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HolderTypeID,HolderTypeName")] AccountHolderType accountHolderType)
        {
            if (ModelState.IsValid)
            {
                db.AccountHolderTypes.Add(accountHolderType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountHolderType);
        }

        // GET: AccountHolderTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolderType accountHolderType = db.AccountHolderTypes.Find(id);
            if (accountHolderType == null)
            {
                return HttpNotFound();
            }
            return View(accountHolderType);
        }

        // POST: AccountHolderTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HolderTypeID,HolderTypeName")] AccountHolderType accountHolderType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountHolderType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountHolderType);
        }

        // GET: AccountHolderTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountHolderType accountHolderType = db.AccountHolderTypes.Find(id);
            if (accountHolderType == null)
            {
                return HttpNotFound();
            }
            return View(accountHolderType);
        }

        // POST: AccountHolderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountHolderType accountHolderType = db.AccountHolderTypes.Find(id);
            db.AccountHolderTypes.Remove(accountHolderType);
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
