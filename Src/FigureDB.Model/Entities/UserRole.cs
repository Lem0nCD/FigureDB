using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 用户权限
    /// </summary>
    public class UserRole : BaseEntityGuid
    {
        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// 权限外键
        /// </summary>
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
