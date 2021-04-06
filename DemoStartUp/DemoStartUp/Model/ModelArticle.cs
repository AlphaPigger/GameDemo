using System;
using System.Collections.Generic;
using System.Text;

namespace DemoStartUp.Model
{
    /// <summary>
    /// 物品类
    /// </summary>
    public class ModelArticle
    {
        /// <summary>
        /// Id/编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 分组Id
        /// </summary>
        public int GroupId { get; set; }
    }
}
