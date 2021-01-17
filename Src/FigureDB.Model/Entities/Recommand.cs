using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    public class Recommand : BaseEntityGuid
    {
        /// <summary>
        /// 封面图片
        /// </summary>
        public Guid FigureImageId { get; set; }
        public FigureImage FigureImage { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 手办外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
    }
}
