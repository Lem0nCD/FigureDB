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
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        public User User { get; set; }

        public IList<Offer> Offers { get; set; }
    }
}
