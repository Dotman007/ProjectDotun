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
    public class AgencyController : Controller
    {
        private AGENCYDB db = new AGENCYDB();

      
             public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.FieldSortParm = String.IsNullOrEmpty(sortOrder) ? "field_desc" : "";
            ViewBag.LocationSortParm = sortOrder == "Location" ? "location_desc" : "Location";
            ViewBag.LevelParm = sortOrder == "Level" ? "level_desc" : "Level";
            ViewBag.AddressSortParm = sortOrder == "Address" ? "address_desc" : "Address";
            ViewBag.QualificationSortParm = sortOrder == "Qualification" ? "qualification_desc" : "Qualification";
            ViewBag.JobSortParm = sortOrder == "Job" ? "job_desc" : "Job";

            var firms = from f in db.Agencys
                        select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                firms = firms.Where(f => f.Field.ToUpper().Contains(searchString.ToUpper())
                    ||
                    f.Location.ToUpper().Contains(searchString.ToUpper()) || f.Job.ToUpper().Contains(searchString.ToUpper())
                || f.Level.ToUpper().Contains(searchString.ToUpper()) || f.Address.ToUpper().Contains(searchString.ToUpper()) || f.Qualification.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "firmname_desc":
                    firms = firms.OrderByDescending(f => f.Job);
                    break;
                case "location":
                    firms = firms.OrderBy(f => f.Field);
                    break;
                case "organizationofemployement":
                    firms = firms.OrderBy(f => f.Level);
                    break;
                case "recruitmentfirm_address":
                    firms = firms.OrderBy(f => f.Qualification);
                    break;
                case "location_desc":
                    firms = firms.OrderByDescending(f => f.Location);
                    break;
                case "qualification_desc":
                    firms = firms.OrderByDescending(f => f.Address);
                    break;
                default:
                    firms = firms.OrderBy(f => f.Field);
                    break;
            }

            //var applicants = (from f in db.Recruitment_Firms where f.ApplicantId.Count < 5 select f).ToList();

            return View(firms.ToList());
        }
        [Authorize]
             public ActionResult Agencys(int id)
             {
                 var agencys = db.Agencys.Include(k => k.AgencyType).Where(k => k.AgencyTypeId == id && k.Status == true);

                 if (agencys.Any())
                 {

                     return View(agencys.ToList());
                 }
                 else
                 {
                     ViewBag.Message = "OOOPSS!SORRY ROOMS NOT AVAILABLE AT THE MOMENT CHECK BACK LATER";
                     return View();
                 }
             }
             //}
        [Authorize]
        public ViewResult AgencyDetails(int id)
        {
            Agency agency = db.Agencys.Find(id);
            return View(agency);

        }
        //
        // GET: /Agency/

        //public ViewResult Index()
        //{
        //    var agencys = db.Agencys.Include(a => a.AgencyType);
        //    return View(agencys.ToList());
        //}

        //
        // GET: /Agency/Details/5
        [Authorize(Roles="Admin")]
        public ViewResult Details(int id)
        {
            Agency agency = db.Agencys.Find(id);
            return View(agency);
        }

        //
        // GET: /Agency/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AgencyTypeId = new SelectList(db.AgencyTypes, "AgencyTypeId", "AreaOfSpecialization");
            return View();
        } 

        //
        // POST: /Agency/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Agency agency, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), pic);
                    file.SaveAs(path);
                    agency.Logo = file.FileName;
                }
                db.Agencys.Add(agency);
                db.SaveChanges();
                return RedirectToAction("Index");   
            }

            ViewBag.AgencyTypeId = new SelectList(db.AgencyTypes, "AgencyTypeId", "AreaOfSpecialization", agency.AgencyTypeId);
            return View(agency);
        }
        
        //
        // GET: /Agency/Edit/5
 [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Agency agency = db.Agencys.Find(id);
            ViewBag.AgencyTypeId = new SelectList(db.AgencyTypes, "AgencyTypeId", "AreaOfSpecialization", agency.AgencyTypeId);
            return View(agency);
        }

        //
        // POST: /Agency/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Agency agency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgencyTypeId = new SelectList(db.AgencyTypes, "AgencyTypeId", "AreaOfSpecialization", agency.AgencyTypeId);
            return View(agency);
        }

        //
        // GET: /Agency/Delete/5
 [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Agency agency = db.Agencys.Find(id);
            return View(agency);
        }

        //
        // POST: /Agency/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Agency agency = db.Agencys.Find(id);
            db.Agencys.Remove(agency);
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