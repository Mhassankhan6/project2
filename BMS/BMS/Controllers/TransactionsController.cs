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
    public class TransactionsController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Account).Include(t => t.TransactionStatu).Include(t => t.User);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.SourceAccountNumber = new SelectList(db.Accounts, "AccountID", "AccountNumber");
            ViewBag.StatusID = new SelectList(db.TransactionStatus, "StatusID", "StatusName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,TransactionType,Amount,TransactionDate,Description,SourceAccountNumber,DestinationAccountNumber,UserID,StatusID")] Transaction transaction)
        {
            //Account srcAcc = db.Accounts.Find(srcAcc.SourceAccountNumber);
            //Account dstAcc = db.Accounts.Find(dstAcc.DestinationAccountNumber);

            if (ModelState.IsValid)
            {
                //if (sourceAccount == null || destinationAccount == null)
                //{
                //    return HttpNotFound();
                //}

                //if (srcAcc.AccountBalance >= transaction.Amount)
                //{
                //    srcAcc.AccountBalance -= transaction.Amount;
                //    dstAcc.AccountBalance += transaction.Amount;

                //    ViewBag.Message = "Transfer Successful!";
                //}

                //else
                //{
                //    ViewBag.Message = "Insufficient Balance!";
                //}

                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SourceAccountNumber = new SelectList(db.Accounts, "AccountID", "AccountNumber", transaction.SourceAccountNumber);
            ViewBag.StatusID = new SelectList(db.TransactionStatus, "StatusID", "StatusName", transaction.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", transaction.UserID);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.SourceAccountNumber = new SelectList(db.Accounts, "AccountID", "AccountNumber", transaction.SourceAccountNumber);
            ViewBag.StatusID = new SelectList(db.TransactionStatus, "StatusID", "StatusName", transaction.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", transaction.UserID);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,TransactionType,Amount,TransactionDate,Description,SourceAccountNumber,DestinationAccountNumber,UserID,StatusID")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SourceAccountNumber = new SelectList(db.Accounts, "AccountID", "AccountNumber", transaction.SourceAccountNumber);
            ViewBag.StatusID = new SelectList(db.TransactionStatus, "StatusID", "StatusName", transaction.StatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", transaction.UserID);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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
