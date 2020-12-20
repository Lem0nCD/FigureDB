using FigureDB.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inspirator.Model.Entities
{
    public class User : BaseEntity
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
        public virtual IList<UserIdentity> UserIdentitys { get; set; }
    }
}
