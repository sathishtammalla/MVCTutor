using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutor.ViewModel
{
    public class EmployeeListVM : BaseViewModel
    {
        public List<EmployeVM> Employees { get; set; }
       // public string UserName { get; set; }
        //public FooterVM Footer { get; set; }
    }
}