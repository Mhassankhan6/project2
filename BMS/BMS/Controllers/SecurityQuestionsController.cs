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
    public class SecurityQuestionsController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: SecurityQuestions
        public ActionResult Index()
        {
            var securityQuestions = db.SecurityQuestions.Include(s => s.User);
            return View(securityQuestions.ToList());
        }

        // GET: SecurityQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityQuestion securityQuestion = db.SecurityQuestions.Find(id);
            if (securityQuestion == null)
            {
                return HttpNotFound();
            }
            return View(securityQuestion);
        }

        // GET: SecurityQuestions/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: SecurityQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionID,SecurityQuestion1,Answer,UserID")] SecurityQuestion securityQuestion)
        {
            if (ModelState.IsValid)
            {
                db.SecurityQuestions.Add(securityQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", securityQuestion.UserID);
            return View(securityQuestion);
        }

        // GET: SecurityQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityQuestion securityQuestion = db.SecurityQuestions.Find(id);
            if (securityQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", securityQuestion.UserID);
            return View(securityQuestion);
        }

        // POST: SecurityQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,SecurityQuestion1,Answer,UserID")] SecurityQuestion securityQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", securityQuestion.UserID);
            return View(securityQuestion);
        }

        // GET: SecurityQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityQuestion securityQuestion = db.SecurityQuestions.Find(id);
            if (securityQuestion == null)
            {
                return HttpNotFound();
            }
            return View(securityQuestion);
        }

        // POST: SecurityQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecurityQuestion securityQuestion = db.SecurityQuestions.Find(id);
            db.SecurityQuestions.Remove(securityQuestion);
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
