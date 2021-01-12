using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.WebAPI.ViewModels
{
    public class CreateFigureViewModel
    {
        /// <summary>
        /// 模型信息名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模型信息中文名字
        /// </summary>
        public string CHNName { get; set; }

        /// <summary>
        /// 比例
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public float Dimensions { get; set; }

        /// <summary>
        /// 材质
        /// </summary>
        public string Materials { get; set; }

        /// <summary>
        /// 发售日（出荷）
        /// </summary>
        public DateTime Release { get; set; }

        /// <summary>
        /// 发行商
        /// </summary>
        public int PublishedId { get; set; }

        /// <summary>
        /// 制作商
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// 原型作品外键
        /// </summary>
        public int OriginId { get; set; }

        /// <summary>
        /// 原型角色外键
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        /// 系列外键
        /// </summary>
        public int SeriesId { get; set; }

        public List<int> Tags { get; set; }
    }
}
