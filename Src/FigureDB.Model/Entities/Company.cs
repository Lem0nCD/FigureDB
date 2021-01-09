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
        /// 公司名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 公司中文名字
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
