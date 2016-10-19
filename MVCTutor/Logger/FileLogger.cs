using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCTutor.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("C://Sathish//" + DateTime.Now.ToString("MM-DD-YYYY hh mm ss") + ".txt",
                new string[]
                {
                    "Message :" + e.Message,
                    "Stack Trace :" + e.StackTrace
                });
        }
    }
}