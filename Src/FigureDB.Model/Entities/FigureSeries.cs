using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 模型-系列
    /// </summary>
    public class FigureSeries : BaseEntityGuid
    {
        /// <summary>
        /// 系列外键
        /// </summary>
        public int SeriesId { get; set; }
        public Series Series { get; set; }

        /// <summary>
        /// 模型外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
    }
}
