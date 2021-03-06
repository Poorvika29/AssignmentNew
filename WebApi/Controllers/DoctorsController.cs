﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorModel;
using PagedList.Mvc;
using PagedList;

namespace WebApi.Controllers
{



    [AllowAnonymous] // Part 70s
    public class DoctorsController : Controller
    {
        private DoctorEntities db = new DoctorEntities();

        // GET: Doctors

        //[OutputCache(Duration = 10)] //Part 73
        [OutputCache(CacheProfile = "1MinuteCache")]  //Part 74
        
        public ActionResult Index(int? page, string sortBy)  //Part 63 an 64
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.GenderSort = sortBy == "Gender" ? "Gender desc" : "Gender";

            var doctors = db.Doctors.Include(d => d.tblSpeciality).AsQueryable();

            switch (sortBy)
            {
                case "Name desc":
                    doctors = doctors.OrderByDescending(x => x.Name);
                    break;
                case "Gender desc":
                    doctors = doctors.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    doctors = doctors.OrderBy(x => x.Gender);
                    break;
                default:
                    doctors = doctors.OrderBy(x => x.Name);
                    break;
            }

            return View(doctors.ToList().ToPagedList(page ?? 1, 3));
        }
        public ActionResult PartialView1()
        {
            var doctors = db.Doctors.Include(d => d.tblSpeciality);
            return View(doctors.ToList());
        }
        // GET: Doctors/Details/5


        [AcceptVerbs(HttpVerbs.Get)]  //Part 67
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }


            return View(doctor);

            //Company company = new Company();    // Part 41
            //return View(company);
        }
        public ActionResult Details_44(int? id)         //Part 44
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            ViewData["Doctordata"] = doctor;
            return View(doctor);
        }
        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.Speciality = new SelectList(db.tSpecialities, "SpecId", "Speciality");
            return View();
        }

        //Part 89
        public JsonResult IsUserNameAvailable(string Name)
        {
            return Json(!db.Doctors.Any(x => x.Name == Name),
                                                 JsonRequestBehavior.AllowGet);
        }


        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]      //Part 76
        public ActionResult Create([Bind(Include = "Id,Name,Gender,WorkEx,Location,Fee,EmailId,Website,Speciality,date")] Doctor doctor)
        {

            if (db.Doctors.Any(x => x.Name == doctor.Name))
            {
                ModelState.AddModelError("UserName", "UserName already in use");
            }

            if (string.IsNullOrEmpty(doctor.Name)) // Part 28
            {
                ModelState.AddModelError("Name", "The Name field is required.");
            }
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Speciality = new SelectList(db.tSpecialities, "SpecId", "Speciality", doctor.Speciality);
            return View(doctor);
        }

        public ActionResult DoctorBySpeciality()
        {
            var doctorTotals = db.Doctors.Include("Speciality")
                                        .GroupBy(x => x.tblSpeciality.Speciality)
                                        .Select(y => new Totals
                                        {
                                            SpecialityN = y.Key,
                                            Total = y.Count()
                                        }).ToList();
            return View(doctorTotals);
        }


        // GET: Doctors/Edit/5
        public ActionResult Edit_45(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Speciality = new SelectList(db.tSpecialities, "SpecId", "Speciality", doctor.Speciality);
            return View(doctor);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Speciality = new SelectList(db.tSpecialities, "SpecId", "Speciality", doctor.Speciality);
            return View(doctor);
        }





        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Doctor doctor)
        {                                                                            //Part43
            Doctor doctorFromDb = db.Doctors.Single(x=>x.Id == doctor.Id);
            doctorFromDb.Id = doctor.Id;
            doctorFromDb.date = doctor.date;
            //doctorFromDb.EmailId = doctor.EmailId;
            doctor.EmailId = doctorFromDb.EmailId;
            doctorFromDb.Website = doctor.Website;
            doctorFromDb.WorkEx = doctor.WorkEx;
            doctorFromDb.Speciality = doctor.Speciality;
            doctorFromDb.Location = doctor.Location;
            doctorFromDb.Gender = doctor.Gender;
            doctorFromDb.Fee = doctorFromDb.Fee;
            doctorFromDb.Name = doctor.Name;


            if (ModelState.IsValid)
            {
                db.Entry(doctorFromDb).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id = doctor.Id});
            }
            ViewBag.Speciality = new SelectList(db.tSpecialities, "SpecId", "Speciality", doctor.Speciality);
            return View(doctorFromDb);
        }

        //public ActionResult Edit([Bind(Exclude = "Name")] Doctor doctor)
        //{ //Part28
        //    Doctor doctorFromDb = db.Doctors.Single(x => x.Id == doctor.Id);
        //    doctorFromDb.Id = doctor.Id;
        //    doctorFromDb.date = doctor.date;
        //    doctorFromDb.EmailId = doctor.EmailId;
        //    doctorFromDb.Website = doctor.Website;
        //    doctorFromDb.WorkEx = doctor.WorkEx;
        //    doctorFromDb.Speciality = doctor.Speciality;
        //    doctorFromDb.Location = doctor.Location;
        //    doctorFromDb.Gender = doctor.Gender;
        //    doctorFromDb.Fee = doctorFromDb.Fee;
        //    doctor.Name = doctorFromDb.Name;


        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(doctorFromDb).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Speciality = new SelectList(db.tSpecialities, "SpecId", "Speciality", doctor.Speciality);
        //    return View(doctorFromDb);
        //}


        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
