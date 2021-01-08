using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 模型信息
    /// </summary>
    public class Figure : BaseEntityGuid
    {
        /// <summary>
        /// 原名
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string CHNName { get; set; }

        /// <summary>
        /// 比例
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public float Dimensions { get; set; }

        /// <summary>
        /// 材质
        /// </summary>
        public string Materials { get; set; }

        /// <summary>
        /// 发售日（出荷）
        /// </summary>
        public DateTime Release { get; set; }

        /// <summary>
        /// 发行商
        /// </summary>
        public int PublishedId { get; set; }
        public Company Publiced { get; set; }

        /// <summary>
        /// 制作商
        /// </summary>
        public int ManufacturerId { get; set; }
        public Company Manufacturer { get; set; }

        /// <summary>
        /// 报价
        /// </summary>
        public IList<Offer> Offers { get; set; }

        /// <summary>
        /// 新闻
        /// </summary>
        public IList<News> News { get; set; }

        /// <summary>
        /// 收藏
        /// </summary>
        public IList<Favorite> Favorites { get; set; }

        /// <summary>
        /// 商店
        /// </summary>
        public IList<Shop> Shops { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public IList<Comment> Comments { get; set; }

        /// <summary>
        /// 原型作品外键
        /// </summary>
        public int OriginId { get; set; }
        public Origin Origin { get; set; }

        /// <summary>
        /// 原型角色外键
        /// </summary>
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        /// <summary>
        /// 系列外键
        /// </summary>
        public Guid FigureSerisesId { get; set; }
        public FigureSeries FigureSeries { get; set; }

        /// <summary>
        /// 图片外键
        /// </summary>
        public IList<FigureImage> FigureImages { get; set; }

        /// <summary>
        /// 模型-分类
        /// </summary>
        public IList<FigureCategory> FigureCategories { get; set; }

        /// <summary>
        /// 模型-标签
        /// </summary>
        public IList<FigureTag> FigureTags { get; set; }

        /// <summary>
        /// 制作人
        /// </summary>
        public IList<ArtistJob> ArtistJobs { get; set; }
    }
}
