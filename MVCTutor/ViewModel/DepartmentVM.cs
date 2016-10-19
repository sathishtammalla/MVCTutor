using MVCTutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutor.ViewModel
{
    public class DepartmentVM
    {
      //  public List<Departments> Departments { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
    }
}