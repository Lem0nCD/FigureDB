using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FigureDB.WebAPI.Util
{
    public class CreateFIle
    {
        //public static CreateImageFile(string path, IFormFile file)
        //{
        //    if (file.Length > 0)
        //    {
        //        string[] contentTypeStrings = file.ContentType.Split('/');
        //        if (contentTypeStrings.FirstOrDefault() == "image")
        //        {
        //            switch (contentTypeStrings.Last())
        //            {
        //                case "jpeg":
        //                    path = path + ".jpg";
        //                    break;                        
        //                case "png":
        //                    path = path + ".png";
        //                    break;
        //            }

        //            using (var stream = System.IO.File.Create(path))
        //            {
        //                await file.CopyToAsync(stream);
        //            }
        //        }
        //    }
        //}
    }
}
