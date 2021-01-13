using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User : BaseEntityGuid
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 用户身份
        /// </summary>
        public virtual IList<UserIdentity> UserIdentitys { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public Guid UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        /// <summary>
        /// 商店
        /// </summary>
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public IList<Comment> Comments { get; set; }

        /// <summary>
        /// 收藏
        /// </summary>
        public IList<Favorite> Favorites { get; set; }

        /// <summary>
        /// 新闻
        /// </summary>
        //public IList<News> News { get; set; }


    }
}
