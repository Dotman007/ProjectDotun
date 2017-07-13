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
    public class AgencyTypeController : Controller
    {
        private AGENCYDB db = new AGENCYDB();

        //
        // GET: /AgencyType/

        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(db.AgencyTypes.ToList());
        }
        //public ViewResult AgencyCats()
        //{
        //    return View(db.AgencyTypes.ToList());
        //}
       
        public ViewResult AgencyCats(string sortOrder, string searchString)
        {
            ViewBag.AreaOfSpecializationSortParm = String.IsNullOrEmpty(sortOrder) ? "areaofspe_desc" : "";
            ViewBag.LocationSortParm = sortOrder == "Location" ? "location_desc" : "Location";
            ViewBag.LevelParm = sortOrder == "Level" ? "level_desc" : "Level";
            ViewBag.AddressSortParm = sortOrder == "Address" ? "address_desc" : "Address";
            ViewBag.QualificationRequiredSortParm = sortOrder == "QualificationRequired" ? "qualificationrequired_desc" : "QualificationRequired";
            ViewBag.AvailableJobSortParm = sortOrder == "AvailableJob" ? "availablejob_desc" : "AvailableJob";

            var firms = from f in db.AgencyTypes
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                firms = firms.Where(f => f.AreaOfSpecialization.ToUpper().Contains(searchString.ToUpper())
                    ||
                    f.Location.ToUpper().Contains(searchString.ToUpper()) || f.AvailableJob.ToUpper().Contains(searchString.ToUpper())
                || f.Level.ToUpper().Contains(searchString.ToUpper()) || f.Address.ToUpper().Contains(searchString.ToUpper()) || f.QualificationRequired.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "firmname_desc":
                    firms = firms.OrderByDescending(f => f.AvailableJob);
                    break;
                case "location":
                    firms = firms.OrderBy(f => f.AreaOfSpecialization);
                    break;
                case "organizationofemployement":
                    firms = firms.OrderBy(f => f.Level);
                    break;
                case "recruitmentfirm_address":
                    firms = firms.OrderBy(f => f.QualificationRequired);
                    break;
                case "location_desc":
                    firms = firms.OrderByDescending(f => f.Location);
                    break;
                case "qualification_desc":
                    firms = firms.OrderByDescending(f => f.Address);
                    break;
                default:
                    firms = firms.OrderBy(f => f.AreaOfSpecialization);
                    break;
            }

            

            return View(firms.ToList());
        }

       
        // GET: /AgencyType/Details/5

        public ViewResult Details(int id)
        {
            AgencyType agencytype = db.AgencyTypes.Find(id);
            return View(agencytype);
        }

        //
        // GET: /AgencyType/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AgencyType/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(AgencyType agencytype,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), pic);
                    file.SaveAs(path);
                    agencytype.Image = file.FileName;
                }
                db.AgencyTypes.Add(agencytype);
                db.SaveChanges();
                return RedirectToAction("Success");  
            }

            return View(agencytype);
        }
        public ActionResult Success()
        {
            return View();

        }
        //
        // GET: /AgencyType/Edit/5
 [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            AgencyType agencytype = db.AgencyTypes.Find(id);
            return View(agencytype);
        }

        //
        // POST: /AgencyType/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(AgencyType agencytype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencytype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agencytype);
        }

        //
        // GET: /AgencyType/Delete/5
 [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            AgencyType agencytype = db.AgencyTypes.Find(id);
            return View(agencytype);
        }

        //
        // POST: /AgencyType/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AgencyType agencytype = db.AgencyTypes.Find(id);
            db.AgencyTypes.Remove(agencytype);
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