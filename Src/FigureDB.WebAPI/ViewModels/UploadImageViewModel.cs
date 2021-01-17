using FigureDB.Model.Enum;
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
        public IFormFile File { get; set; }
        [FromForm]
        public string ParentId { get; set; }
        [FromForm]
        public string ImageIndex { get; set; }
        [FromForm]
        public FigureImageType FigureImageType { get; set; }
    }
}
