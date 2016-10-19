using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCTutor.DataAccessLayer;
using MVCTutor.Model;
using MVCTutor.Filters;

namespace MVCTutor.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
            /*
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "Sathish";
            emp.LastName = "Tammalla";
            emp.Salary = 10000;
            employees.Add(emp);
            Employee emp1 = new Employee();
            emp1.FirstName = "Anusha";
            emp1.LastName = "Bhimala";
            emp1.Salary = 12000;
            employees.Add(emp1);
            */
           // return employees;
        }

        
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;

        }

        public bool IsValidUser(UserDetails user)
        {
            if(user.UserName == "Admin" && user.Password == "Admin")
            {
                return true;
            }else
            {
                return false;
            }

        }

        public UserStatus GetUserValidity(UserDetails user)
        {
            if(user.UserName =="Admin" && user.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else 
                if(user.UserName == "Sathish" && user.Password == "Sanni")
            {
                return UserStatus.AuthenticatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        public List<Departments> GetDepartments()
        {
            SalesERPDAL dept = new SalesERPDAL();
            return dept.Departments.ToList();
        }

        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.AddRange(employees);
            salesDal.SaveChanges();

        }

    }
}