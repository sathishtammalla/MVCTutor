using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTutor.Models
{
    public class UserDetails
    {
        [StringLength(7,MinimumLength=2,ErrorMessage = "UserName lenth should between 2 and 7")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}