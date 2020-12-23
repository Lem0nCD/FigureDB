using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 工作类型
    /// </summary>
    public class Job : BaseEntity<int>
    {
        /// <summary>
        /// 工作类型名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 制作人员
        /// </summary>
        public IList<ArtistJob> ArtistJobs { get; set; }
    }
}
