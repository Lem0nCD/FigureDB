using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 模型-类别
    /// </summary>
    public class FigureCategory : BaseEntityGuid
    {
        /// <summary>
        /// 模型外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }

        /// <summary>
        /// 类别外键
        /// </summary>
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
