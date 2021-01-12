using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.WebAPI.ViewModels
{
    public class UploadImageViewModel
    {
        [FromForm]
        public IFormFile file { get; set; }
        [FromForm]
        public string id { get; set; }        
        [FromForm]
        public string imageType { get; set; }
    }
}
