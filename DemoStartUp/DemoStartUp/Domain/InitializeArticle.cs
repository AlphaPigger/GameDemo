using DemoStartUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoStartUp.Domain
{
    public class InitializeArticle
    {
        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        public List<ModelArticle> InitializeData()
        {
            var result = new List<ModelArticle>();

            for (int i = 1; i < 16; i++)
            {
                var groupId = 0;
                if (i >= 1 && i <= 3)
                    groupId = 1;
                else if (i > 3 && i <= 8)
                    groupId = 2;
                else
                    groupId = 3;
                 

                result.Add(new ModelArticle 
                {
                    Id=i,
                    Name= "Toothpick",
                    GroupId=groupId
                });
            }

            return result;
        }

        /// <summary>
        /// 基于分组渲染
        /// </summary>
        /// <param name="modelArticles"></param>
        public void Rendering(List<ModelArticle> modelArticles)
        {
            var strTem = string.Empty;

            modelArticles.GroupBy(item=>item.GroupId);
        }
    }
}
