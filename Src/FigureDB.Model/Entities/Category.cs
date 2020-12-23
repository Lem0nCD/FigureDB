using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 类别/属性
    /// </summary>
    public class Category : BaseEntity<int>
    {
        /// <summary>
        /// 类别名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模型-类别
        /// </summary>
        public IList<FigureCategory> FigureCategories { get; set; }
    }
}
