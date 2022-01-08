using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace TravelExperience.MVC.Controllers.HelperClasses
{
    public class ImageInfo
    {
        public string ImageBase64 { get; set; }
        public string ImageType { get; set; }
        public Size ImageSize { get; set; }
    }
}