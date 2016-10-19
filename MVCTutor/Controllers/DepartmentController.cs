using MVCTutor.Models;
using MVCTutor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutor.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult GetDepartments()
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            List<Departments> dept = new List<Departments>();
            List<DepartmentVM> Departments = new List<DepartmentVM>();
            DepartmentListVM deps = new DepartmentListVM();

            dept = ebl.GetDepartments();
          

            foreach(Departments dep in dept)
            {
                DepartmentVM dVM = new DepartmentVM();
                dVM.DepartmentId = dep.DepartmentId;
                dVM.DepartmentName = dep.DepartmentName;
                dVM.Location = dep.Location;

                Departments.Add(dVM);
            }
            deps.DepartmentsList = Departments;
          //  deps.UserName = "Admin";
            return View("Departments",deps);
        }
    }
}