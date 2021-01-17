using FigureDB.Model.Entities.Base;
using FigureDB.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    public class FigureImage : BaseEntityGuid
    {
        /// <summary>
        /// 手办外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
        /// <summary>
        /// 图片外键
        /// </summary>
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>
        public FigureImageType FigureImageType { get; set; } = FigureImageType.Deatil;
    }
}
