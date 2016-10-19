using MVCTutor.Filters;
using MVCTutor.Models;
using MVCTutor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCTutor.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
       
        public string GetString()
        {
            return "Welcome, Sathish Started MVC Again!!";
        }

        [Authorize]
        [HeaderFooterFilter]
        [Route("Employee/List")]
        public ActionResult Index()
        {
            Employee emp = new Employee();
            emp.FirstName = "Sathish";
            emp.LastName = "Tammalla";
            emp.Salary = 100000;

            // ViewData["Employee"] = emp;
            //ViewBag.Employee = emp;

            EmployeVM vm = new EmployeVM();

            vm.EmployeeName = emp.FirstName + " " + emp.LastName;
            vm.UserName = "Sathish";
            vm.SalaryColor = "blue";
            vm.Salary = Convert.ToString(emp.Salary);

            EmployeeListVM empListView = new EmployeeListVM();
            empListView.UserName = User.Identity.Name;
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            List<Employee> employees = new List<Employee>();
            employees = ebl.GetEmployees();
            List<EmployeVM> employeeVMs = new List<EmployeVM>();

            foreach( Employee empl in employees)
            {
                EmployeVM emplVM = new EmployeVM();
                emplVM.EmployeeName = empl.FirstName + " " + empl.LastName;
                emplVM.Salary = Convert.ToString(empl.Salary);
                if(empl.Salary > 10000 && empl.Salary <= 20000)
                {
                    emplVM.SalaryColor = "blue";
                }
                else if (empl.Salary > 20000 && empl.Salary <= 30000)
                {
                    emplVM.SalaryColor = "green";
                }
                else
                {
                    emplVM.SalaryColor = "yellow";
                }
                employeeVMs.Add(emplVM);
            }

            empListView.Employees = employeeVMs;
            empListView.FooterData = new FooterVM();
            //  empListView.Footer.CompanyName = "Sathish MVC Tutorial";
             empListView.FooterData.CompanyName =  "Sathish MVC Tutorial";
             empListView.FooterData.Year = DateTime.Now.Year.ToString();
             empListView.FooterData.Terms = "All Rights are Reserved!";
            empListView.UserName = HttpContext.User.Identity.Name;

           // empListView.UserName = empListView.I;

            return View("Index", empListView);


        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeVM createEmployeeListVM = new CreateEmployeeVM();
            createEmployeeListVM.FooterData = new FooterVM();
            createEmployeeListVM.FooterData.CompanyName = "Sathish Tutorial Labs";
            createEmployeeListVM.FooterData.Year = "2016";
            createEmployeeListVM.FooterData.Terms = "All Rights Reserved!";
            createEmployeeListVM.UserName = HttpContext.User.Identity.Name; 
            return View("CreateEmployee", createEmployeeListVM);
        }

        [AdminFilter, ValidateAntiForgeryToken, HeaderFooterFilter]
        public ActionResult  SaveEmployee(Employee e,string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empbl = new EmployeeBusinessLayer();
                        empbl.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeVM createEmpVM = new CreateEmployeeVM();
                        createEmpVM.FirstName = e.FirstName;
                        createEmpVM.LastName = e.LastName;
                        if(e.Salary > 0 || e.Salary.ToString()!= null)
                        {
                            createEmpVM.Salary = Convert.ToString(e.Salary);
                        }
                        else
                        {
                            createEmpVM.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        createEmpVM.FooterData = new FooterVM();
                        createEmpVM.FooterData.CompanyName = "Sathish Tutorial Labs";
                        createEmpVM.FooterData.Year = "2016";
                        createEmpVM.FooterData.Terms = "All Rights Reserved!";
                        createEmpVM.UserName = HttpContext.User.Identity.Name; 
                            return View("CreateEmployee", createEmpVM);
                    }
                                         
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        [ChildActionOnly]
        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"])){
                return PartialView("AddNewLink");
            }else
            {
                return new EmptyResult();
            }
        }

       
    }
}