using Ajax3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax3.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDbEntities _db;
        public HomeController()
        {
                _db = new EmployeeDbEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllEmployee()
        {
            var data = _db.Employees.ToList();
            return PartialView("_EmployeePartial",data);
        }
        public ActionResult Top3Employee()
        {
            var data = _db.Employees.OrderByDescending(u=>u.Age).Take(3).ToList();
            return PartialView("_EmployeePartial",data);
        }
        public ActionResult Bottom3Employee()
        {
            var data = _db.Employees.OrderBy(u => u.Age).Take(3).ToList();
            return PartialView("_EmployeePartial", data);
        }

    }
    
}