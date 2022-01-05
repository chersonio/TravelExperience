using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.Controllers
{
    public class HelperClass
    {
        public class ImageInfo
        {
            public string ImageBase64 { get; set; }
            public string ImageType { get; set; }
        }

        public static List<ImageInfo> GetImagesForAccommodationFromStorage(string path)
        {
            DirectoryInfo absoluteFile = new DirectoryInfo(path);

            List<ImageInfo> images = new List<ImageInfo>();

            foreach (FileInfo img in absoluteFile.GetFiles()) // get needed extentions from GetFiles.
            {
                FileStream fs = new FileStream(img.FullName, FileMode.Open);
                
                long size = fs.Length;

                byte[] array = new byte[size];

                fs.Read(array, 0, array.Length);

                fs.Close();
                
                images.Add(new ImageInfo { ImageBase64 = Convert.ToBase64String(array), ImageType = img.Extension.TrimStart('.') });
            }

            return images;
        }
    }
}