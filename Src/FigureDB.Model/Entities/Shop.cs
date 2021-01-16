using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;

namespace FigureDB.Model.Entities
{
    public class Shop : BaseEntityGuid
    {
        /// <summary>
        /// 商店名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商店主页
        /// </summary>
        public string Homepage { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public Guid? Icon { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// 报价
        /// </summary>
        public IList<Offer> Offers { get; set; }
    }
}
