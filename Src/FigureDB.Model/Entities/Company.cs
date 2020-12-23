using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 公司
    /// </summary>
    public class Company : BaseEntity<int>
    {
        /// <summary>
        /// 原名
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string CHNName { get; set; }

        /// <summary>
        /// 图标路径
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 主页地址
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 模型-发行商
        /// </summary>
        public IList<Figure> Publiceds { get; set; }

        /// <summary>
        /// 模型-制造商
        /// </summary>
        public IList<Figure> Manufacturers { get; set; }
    }
}
