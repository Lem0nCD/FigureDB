using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    public class FigureImage : BaseEntityGuid
    {
        public Guid ImageId { get; set; }
        public Figure Figure { get; set; }
        public Guid FigureId { get; set; }
    }
}
