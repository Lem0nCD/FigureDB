using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Tag : BaseEntity<int>
    {
        /// <summary>
        /// 标签名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 模型-标签
        /// </summary>
        public IList<FigureTag> FigureTags { get; set; }
    }
}
