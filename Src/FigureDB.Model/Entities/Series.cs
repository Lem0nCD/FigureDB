using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 系列
    /// </summary>
    public class Series : BaseEntity<int>
    {
        /// <summary>
        /// 系列名字
        /// </summary>
        public string Name { get; set; }        
        /// <summary>
        /// 系列中文名字
        /// </summary>
        public string CHNName { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 公司外键
        /// </summary>
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        /// <summary>
        /// 模型-系列
        /// </summary>
        public IList<Figure> Figures { get; set; }
    }
}
