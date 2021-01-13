using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.DTO
{
    public class NewsDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverImageId { get; set; }
        public Guid FigureId { get; set; }
    }
}
