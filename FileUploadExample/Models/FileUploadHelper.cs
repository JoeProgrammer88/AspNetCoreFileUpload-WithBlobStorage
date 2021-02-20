using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadExample.Models
{
    public static class FileUploadHelper
    {
        public enum FileTypes
        {
            Photo, Video, Audio, Text
        }

        public static bool IsFileEmpty(IFormFile file)
        {
            if(file.Length == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidExtension(IFormFile file, FileTypes type)
        {
            string extension = Path.GetExtension(file.FileName).ToLower();
            switch (type)
            {
                case FileTypes.Photo:
                    string[] photoExtensions = { ".png", ".gif", ".jpg" };
                    if (photoExtensions.Contains(extension))
                        return true;
                    return false;
                case FileTypes.Video:
                    break;
                case FileTypes.Audio:
                    break;
                case FileTypes.Text:
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
