using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCTutor.Validations;

namespace MVCTutor.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [FirstNameValidation]
        public string FirstName { get; set; }
        [StringLength(10,ErrorMessage ="String Length shoould not be more than 10 Characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Salary Cannot be null")]
        public int Salary { get; set; }
    }
}