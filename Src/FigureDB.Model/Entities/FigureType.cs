using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    public class FigureType : BaseEntity<int>
    {
        /// <summary>
        /// 类别名
        /// </summary>
        public string Name { get; set; }

        public Guid FigureId { get; set; }
        public Figure Figure { get; set; }
    }
}
