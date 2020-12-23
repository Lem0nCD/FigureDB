using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 制作人员
    /// </summary>
    public class ArtistJob : BaseEntityGuid
    {
        /// <summary>
        /// 制作人员信息外键
        /// </summary>
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        /// <summary>
        /// 工作类型外键
        /// </summary>
        public int JobId { get; set; }
        public Job Job { get; set; }
        
        /// <summary>
        /// 模型外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
    }
}
