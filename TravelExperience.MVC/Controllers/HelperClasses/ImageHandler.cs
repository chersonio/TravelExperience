using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.MVC.ViewModels;
using System.Drawing;

namespace TravelExperience.MVC.Controllers.HelperClasses
{
    public class ImageHandler
    {
        public ImageInfo ImageInfo { get; set; }

        /// <summary>
        /// Checks .thumbnail from input viewModel, <br/>
        /// Returns an error message if something went wrong, else null (For now)
        /// </summary>
        public string ValidateImageExtentionType(AccommodationFormViewModel viewModel)
        {
            if (viewModel.Thumbnail == null)
            {
                return "Error - Please upload a valid image file type with the correct extention";
            }
            // Need to change to ONLY Image filetypes and extentions.
            List<string> imageContentTypes = new List<string>
            {
                "image/jpg",
                "image/jpeg",
                "image/pjpeg",
                "image/gif",
                "image/x-png",
                "image/png"
            };
            List<string> imageExtentions = new List<string>
            {
                ".jpg",
                ".png",
                ".gif",
                ".jpeg"
            };

            // Check the filetypes to be only image else it will return to the initial Accommodation view
            if (!imageContentTypes.Any(x => string.Equals(viewModel.Thumbnail.ContentType, x, StringComparison.OrdinalIgnoreCase)) &&
                !imageExtentions.Any(y => string.Equals(Path.GetExtension(viewModel.Thumbnail.FileName), y, StringComparison.OrdinalIgnoreCase)))
            {
                return "Error - Please upload a valid image file type with the correct extention"; // go again to ViewModel
            }

            // Empty string means all went well.
            return "";
        }

        public static List<ImageInfo> GetImagesForAccommodationFromStorage(string path, Size? imageSize = null)
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

                images.Add(new ImageInfo { 
                    ImageBase64 = Convert.ToBase64String(array), 
                    ImageType = img.Extension.TrimStart('.'), 
                    ImageSize = imageSize ?? new Size { Height = 250, Width = 300 } 
                });
            }
            return images;
        }

        public Dictionary<Accommodation, List<ImageInfo>> GetDictionaryForImagesOfAccommodations(Accommodation accom, Size? imageSize = null)
        {
            var path = @"C:\TravelExperience\Data\Images\Accommodations\" + accom.AccommodationID.ToString();

            var images = ImageHandler.GetImagesForAccommodationFromStorage(path, imageSize);

            var thumbnailOfAccommodations = new Dictionary<Accommodation, List<ImageInfo>>();
            thumbnailOfAccommodations.Add(accom, images);

            return thumbnailOfAccommodations;
        }
    }
}