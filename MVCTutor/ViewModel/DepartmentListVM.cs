using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutor.ViewModel
{
    public class DepartmentListVM
    {
        public List<DepartmentVM> DepartmentsList { get; set; }
        public string UserName { get; set; }
    }
}