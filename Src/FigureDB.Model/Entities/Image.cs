using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    public class Image : BaseEntityGuid
    {
        public string Path { get; set; }
        public IList<FigureImage> FigureImages { get; set; }
        public Guid RecommandId { get; set; }
        public Recommand Recommand { get; set; }
    }
}
