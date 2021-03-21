using Core.Results;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        static string path = System.IO.Directory.GetCurrentDirectory() + @"\wwwroot\Images";
        public static IDataResult<String> AddAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                string filePath = NewPath(file).newPath;
                string imagePath = NewPath(file).Path2;
                string fullPath = filePath +"\\" +imagePath;
                imagePath = "\\Images\\" + imagePath;
                using (FileStream fileStream = System.IO.File.Create(fullPath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return new SuccessDataResult<String>(imagePath, "File Added.");
            }
            return new ErrorDataResult<String>();
        }

        public static IDataResult<String> UpdateAsync(string oldfilepath, IFormFile newfile)
        {
            if (File.Exists(oldfilepath))
            {
                FileHelper.DeleteAsync(oldfilepath);
                string filePath = NewPath(newfile).newPath;
                string imagePath = NewPath(newfile).Path2;
                string fullPath = filePath + "\\" + imagePath;
                imagePath = "\\Images\\" + imagePath;
                using (FileStream fileStream = System.IO.File.Create(fullPath))
                {
                    newfile.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return new SuccessDataResult<String>(imagePath, "File Added");
            }
            return new ErrorDataResult<String>("File Doesn't Exists");

        }

        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static (string newPath, string Path2) NewPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;


            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{creatingUniqueFilename}";

            return (path, $"{creatingUniqueFilename}");
        }
    }
}