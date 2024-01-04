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
    public class AccountsController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Branch).Include(a => a.AccountHolderType).Include(a => a.InterestRateType).Include(a => a.User);
            return View(accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create

        //public ActionResult Create(int id = 0)
        //{
        //    Account acc = new Account();
        //    var obj = db.Accounts.OrderByDescending(c => c.AccountID).FirstOrDefault();
        //    if (id != 0)
        //    {
        //        acc = db.Accounts.Where(x => x.AccountID == id).FirstOrDefault<Account>();
        //    }
        //    else if (obj == null)
        //    {
        //        acc.AccountNumber = "EBAC9221001";
        //    }
        //    else
        //    {
        //        acc.AccountNumber = "EBAC9221" + (Convert.ToInt32(obj.AccountNumber.Substring(9, acc.AccountNumber.Length - 9)) + 1).ToString("D3");
        //    }
        //    return View(acc);
        //}

        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName");
            ViewBag.HolderTypeID = new SelectList(db.AccountHolderTypes, "HolderTypeID", "HolderTypeName");
            ViewBag.RateTypeID = new SelectList(db.InterestRateTypes, "RateTypeID", "RateTypeName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,AccountNumber,AccountType,AccountBalance,InterestRate,AccountStatus,DateOpened,LastTransactionDate,UserID,BranchID,HolderTypeID,RateTypeID")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", account.BranchID);
            ViewBag.HolderTypeID = new SelectList(db.AccountHolderTypes, "HolderTypeID", "HolderTypeName", account.HolderTypeID);
            ViewBag.RateTypeID = new SelectList(db.InterestRateTypes, "RateTypeID", "RateTypeName", account.RateTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", account.UserID);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", account.BranchID);
            ViewBag.HolderTypeID = new SelectList(db.AccountHolderTypes, "HolderTypeID", "HolderTypeName", account.HolderTypeID);
            ViewBag.RateTypeID = new SelectList(db.InterestRateTypes, "RateTypeID", "RateTypeName", account.RateTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", account.UserID);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountID,AccountNumber,AccountType,AccountBalance,InterestRate,AccountStatus,DateOpened,LastTransactionDate,UserID,BranchID,HolderTypeID,RateTypeID")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", account.BranchID);
            ViewBag.HolderTypeID = new SelectList(db.AccountHolderTypes, "HolderTypeID", "HolderTypeName", account.HolderTypeID);
            ViewBag.RateTypeID = new SelectList(db.InterestRateTypes, "RateTypeID", "RateTypeName", account.RateTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", account.UserID);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
