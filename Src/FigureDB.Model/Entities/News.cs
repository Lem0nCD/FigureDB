using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 情报
    /// </summary>
    public class News : BaseEntityGuid
    {
        public string Content { get; set; }
        /// <summary>
        /// 模型外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
