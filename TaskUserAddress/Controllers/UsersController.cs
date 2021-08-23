using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskUserAddress.Models;

namespace TaskUserAddress.Controllers
{
    public class UsersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
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
        public ActionResult Create(UserModel user )
        {
            if (ModelState.IsValid)
            {

                var lastid = db.User.Max(e=>e.IdUser);
                var model = new User();
                model.IdUser = lastid + 1;
                model.Email = user.Email;
                model.UserName = user.UserName;
                db.User.Add(model);
                db.SaveChanges();

                for (int i = 0; i < 3; i++)
                {
                    var address = new UserAddress();
                    var lastidAddress = db.UserAddresses.Max(e => e.AddressId);
                    address.AddressId = lastidAddress + 1;
                    address.IdUser = model.IdUser;
                    address.Address = user.Address[i];
                    address.Country = user.Country[i];
                    address.City = user.City[i];
                    db.UserAddresses.Add(address);
                    db.SaveChanges();
                }
                
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
            User user = db.User.Find(id);
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
        public ActionResult Edit(User user,string[] Address, string[] City, string[] Country)
        {
            if (ModelState.IsValid)
            {
                var model = db.User.Where(e => e.IdUser == user.IdUser).FirstOrDefault();
                model.Email = user.Email;
                model.UserName = user.UserName;
                
                db.SaveChanges();
                var address = db.UserAddresses.Where(e => e.IdUser == user.IdUser).ToList();
                int i = 0;
                foreach (var item in address)
                {
                    item.Address = Address[i];
                    item.City = City[i];
                    item.Country = Country[i];
                    db.SaveChanges();
                    i++;
                }
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
            User user = db.User.Find(id);
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
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            var address = db.UserAddresses.Where(e => e.IdUser == user.IdUser).ToList();
            foreach (var item in address)
            {
                db.UserAddresses.Remove(item);
                db.SaveChanges();
            }

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
