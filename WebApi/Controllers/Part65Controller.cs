using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorModel;


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
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            db.Doctors.Where(x => employeeIdsToDelete.Contains(x.Id)).ToList().ForEach(db.Doctors.DeleteObject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}