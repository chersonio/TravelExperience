using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace TravelExperience.MVC.Controllers.HelperClasses
{
    public class ImageHandler
    {
        public ImageInfo ImageInfo { get; set; }

        public List<ImageInfo> GetImagesForAccommodationFromStorage(string path)
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