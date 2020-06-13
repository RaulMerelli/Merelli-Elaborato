using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imgAPI.Models
{
    public class ImgUpload
    {
        public string FileName { get; set; }
        public int id { get; set; }
    }

    public class container
    {
        public int id { get; set; }
        public string IPaddress { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string downloadFormat { get; set; }
        public DateTime dateTime { get; set; }
        public int version { get; set; }
        public string originalImg { get; set; }
        public string convertedImg { get; set; }
        public string filename { get; set; }
    }
}
