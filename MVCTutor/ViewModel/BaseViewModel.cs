using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutor.ViewModel
{
    public class BaseViewModel
    {
        public string UserName { get; set; }
        public FooterVM FooterData { get; set; }
    }
}