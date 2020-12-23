using FigureDB.Model.Entities.Base;
using FigureDB.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 收藏
    /// </summary>
    public class Favorite : BaseEntityGuid
    {
        /// <summary>
        /// 收藏类型
        /// </summary>
        public FavoriteType Type { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// 模型外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }

    }
}
