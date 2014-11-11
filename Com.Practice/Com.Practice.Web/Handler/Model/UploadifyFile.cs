using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Practice.Web.Handler.Model
{
    public class UploadifyFile
    {
        public string name { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
}