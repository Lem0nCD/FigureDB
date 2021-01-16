using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 制作人员
    /// </summary>
    public class Artist : BaseEntity<int>
    {
        /// <summary>
        /// 制作人员名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 制作人员中文名字
        /// </summary>
        public string CHNName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public Guid? Avator { get; set; }

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
