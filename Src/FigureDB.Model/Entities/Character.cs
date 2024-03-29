﻿using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 原型角色
    /// </summary>
    public class Character : BaseEntity<int>
    {
        /// <summary>
        /// 原型角色名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 原型角色中文名字
        /// </summary>
        public string CHNName { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 角色头像
        /// </summary>
        public Guid? Avatar { get; set; }

        /// <summary>
        /// 模型
        /// </summary>
        public IList<Figure> Figures { get; set; }
        
    }
}
