using FigureDB.Model.Entities.Base;
using System;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 评论
    /// </summary>
    public class Comment : BaseEntityGuid
    {
        /// <summary>
        /// 评论正文
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public int UpVote { get; set; }

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
