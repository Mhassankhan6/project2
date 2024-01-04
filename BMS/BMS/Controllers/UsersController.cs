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
    public class UsersController : Controller
    {
        private BankManagementSystemEntities db = new BankManagementSystemEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Username,Password,BirthDate,Gender,Email,PhoneNumber,PostalCode,Address,City,State,Country,Occupation,RegistrationDate,LastLogin,AccountStatus")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Username,Password,BirthDate,Gender,Email,PhoneNumber,PostalCode,Address,City,State,Country,Occupation,RegistrationDate,LastLogin,AccountStatus")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser, int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            if (!ModelState.IsValid)
            {
                //using (BankManagementSystemEntities DB = new BankManagementSystemEntities())
                {
                    var obj = db.Users.Where(u => u.Username.Equals(objUser.Username) && u.Password.Equals(objUser.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        User user = db.Users.Find(id);
                        
                        //Session["UserID"] = obj.UserID.ToString();
                        //Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("Details", "Accounts", new {id = obj.UserID});
                    }
                }
            }
            return View(objUser);
        }

        //public ActionResult UserDashBoard()
        //{
        //    if (Session["UserID"] != null)
        //    {
        //        using (BankManagementSystemEntities DB = new BankManagementSystemEntities())
        //        {
        //            int userId = Convert.ToInt32(Session["UserID"]);
        //            var userData = DB.Users.Where(u => u.UserID == userId).FirstOrDefault();

        //            if (userData != null)
        //            {
        //                return View(userData);
        //            }
        //            else
        //            {
        //                // Handle the case where user data is not found.
        //                return View("Error");
        //            }
        //        }
        //    }

        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}
    }
}
