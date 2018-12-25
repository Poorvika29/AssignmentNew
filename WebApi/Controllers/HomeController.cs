using DoctorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {

        private DoctorEntities db = new DoctorEntities();

        public ActionResult Index()
        {

            //ViewBag.Specialities = new SelectList(db.tSpecialities, "SpecId", "Speciality");     //Part 34

            //ViewBag.Specialities = new SelectList(db.tSpecialities, "SpecId", "Speciality", "10"); // Part 35

            //List<SelectListItem> selectListItems = new List<SelectListItem>();      //Part 35

            //foreach (tSpeciality speciality in db.tSpecialities)
            //{
            //    SelectListItem selectListItem = new SelectListItem
            //    {
            //        Text = speciality.Speciality,
            //        Value = speciality.SpecId.ToString(),
            //        Selected = speciality.IsSelected.HasValue ? speciality.IsSelected.Value : false
            //    };
            //    selectListItems.Add(selectListItem);
            //}

            //ViewBag.Specialities = selectListItems;
            //return View();

            Company ts = new Company("Poorvi");
            
        ViewBag.Specialities = new SelectList(ts.Departments, "SpecId", "Speciality");
            ViewBag.CompanyName = ts.CompanyName;
            return View(ts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}