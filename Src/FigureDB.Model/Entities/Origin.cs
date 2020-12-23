using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 原型作品
    /// </summary>
    public class Origin : BaseEntity<int>
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 模型
        /// </summary>
        public IList<Figure> Figures { get; set; }

    }
}
