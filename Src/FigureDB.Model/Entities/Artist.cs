using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 制作人员信息
    /// </summary>
    public class Artist : BaseEntity<int>
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
        /// 头像路径
        /// </summary>
        public string Avator { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 制作人员
        /// </summary>
        public IList<ArtistJob> ArtistJobs { get; set; }
    }
}
