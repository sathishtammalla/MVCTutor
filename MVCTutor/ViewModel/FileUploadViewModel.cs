using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutor.ViewModel
{
    public class FileUploadViewModel:BaseViewModel
    {
        public HttpPostedFileBase fileUpload { get; set; }
    }
}