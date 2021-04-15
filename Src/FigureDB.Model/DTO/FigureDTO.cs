using FigureDB.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.DTO
{
    public class FigureDTO
    {
        /// <summary>
        /// 手办Id
        /// </summary>
        public Guid Id { get; set; }
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
        public string Published { get; set; }

        /// <summary>
        /// 制作商
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 原型作品
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// 原型角色
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        /// 系列外键
        /// </summary>
        public int SeriesId { get; set; }
        public string Series { get; set; }
        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImagePath { get; set; }

        /// <summary>
        /// 类型名字
        /// </summary>
        public string FigureType { get; set; }
    }
}
