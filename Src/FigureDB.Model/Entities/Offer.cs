using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 报价
    /// </summary>
    public class Offer : BaseEntityGuid
    {
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商店外键
        /// </summary>
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }

        /// <summary>
        /// 手办外键
        /// </summary>
        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
    }
}
