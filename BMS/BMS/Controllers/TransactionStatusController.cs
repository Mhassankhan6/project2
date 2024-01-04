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
    public class TransactionStatusController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: TransactionStatus
        public ActionResult Index()
        {
            return View(db.TransactionStatus.ToList());
        }

        // GET: TransactionStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionStatu transactionStatu = db.TransactionStatus.Find(id);
            if (transactionStatu == null)
            {
                return HttpNotFound();
            }
            return View(transactionStatu);
        }

        // GET: TransactionStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,StatusName")] TransactionStatu transactionStatu)
        {
            if (ModelState.IsValid)
            {
                db.TransactionStatus.Add(transactionStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactionStatu);
        }

        // GET: TransactionStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionStatu transactionStatu = db.TransactionStatus.Find(id);
            if (transactionStatu == null)
            {
                return HttpNotFound();
            }
            return View(transactionStatu);
        }

        // POST: TransactionStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,StatusName")] TransactionStatu transactionStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionStatu);
        }

        // GET: TransactionStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionStatu transactionStatu = db.TransactionStatus.Find(id);
            if (transactionStatu == null)
            {
                return HttpNotFound();
            }
            return View(transactionStatu);
        }

        // POST: TransactionStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionStatu transactionStatu = db.TransactionStatus.Find(id);
            db.TransactionStatus.Remove(transactionStatu);
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
