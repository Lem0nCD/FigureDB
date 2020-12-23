using FigureDB.Model.Entities.Base;
using System.Collections.Generic;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 权限
    /// </summary>
    public class Role : BaseEntity<int>
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///描述
        /// </summary>
        public string Description { get; set; }

        public IList<UserRole> UserRoles { get; set; }

    }
}
