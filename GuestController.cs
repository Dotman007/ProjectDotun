using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agencies.Models;

namespace Agencies.Controllers
{ 
    public class GuestController : Controller
    {
        private AGENCYDB db = new AGENCYDB();

        //
        // GET: /Guest/
        [Authorize(Roles="Admin")]
        public ViewResult Index()
        {
            return View(db.Guests.ToList());
        }
       [Authorize]
        public ActionResult Update(int? id)
        {
            Guest customer = db.Guests.Find(id);
            return View(customer);
        }
        [Authorize]
        public ViewResult MyProfile()
        {

            int id = db.Guests.SingleOrDefault(c => c.UserName == User.Identity.Name).GuestId;
            Guest guest = db.Guests.Find(id);
            return View(guest);
        }
        [Authorize]
        public ActionResult MyDashBourd()
        {
            return PartialView("MyDashBourd");
        }

        //
        // GET: /Guest/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            Guest guest = db.Guests.Find(id);
            return View(guest);
        }

        //
        // GET: /Guest/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 


       
        //
        // POST: /Guest/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Success");  
            }


            return View(guest);
        }
        [Authorize]
        public ActionResult Success()
        {
            return View();
        } 

       
        
        //
        // GET: /Guest/Edit/5
 [Authorize]
        public ActionResult Edit(int id)
        {
            Guest guest = db.Guests.Find(id);
            return View(guest);
        }

        //
        // POST: /Guest/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        //
        // GET: /Guest/Delete/5
 [Authorize(Roles="Admin")]
        public ActionResult Delete(int id)
        {
            Guest guest = db.Guests.Find(id);
            return View(guest);
        }

        //
        // POST: /Guest/Delete/5
        [Authorize(Roles="Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}