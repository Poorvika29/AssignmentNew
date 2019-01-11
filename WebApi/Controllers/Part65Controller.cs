using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorModel;

// Git Demo 

namespace WebApi.Controllers
{
    public class Part65Controller : Controller
    {
        private DoctorEntities db = new DoctorEntities();

        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }

        [HttpPost]
        [RequireHttps]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            var list = db.Doctors.Where(x => employeeIdsToDelete.Contains(x.Id)).ToList();
            foreach(var item in list)
            {
                db.Doctors.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}