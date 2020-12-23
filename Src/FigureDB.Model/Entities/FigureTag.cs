using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 模型-标签
    /// </summary>
    public class FigureTag : BaseEntityGuid
    {
        /// <summary>
        /// 标签外键
        /// </summary>
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        /// <summary>
        /// 模型外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
    }
}
