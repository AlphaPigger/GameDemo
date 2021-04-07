using DemoStartUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoStartUp.Domain
{
    public class InitializeArticle
    {
        private List<ModelArticle> _modelArticles=new List<ModelArticle>();
        private string _articleName;

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        public void InitializeData(string articleName)
        {
            //物品名称
            _articleName = articleName;

            //物品初始化
            for (int i = 1; i < 16; i++)
            {
                var groupId = 0;
                if (i >= 1 && i <= 3)
                    groupId = 1;
                else if (i > 3 && i <= 8)
                    groupId = 2;
                else
                    groupId = 3;


                _modelArticles.Add(new ModelArticle 
                {
                    Id=i,
                    Name= articleName,
                    GroupId=groupId
                });
            }
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="modelArticles"></param>aa
        public void Rendering()
        {
            //字典数据
            var temDic=_modelArticles.GroupBy(item=>item.GroupId).ToDictionary(v=>v.Key,k=>k.Where(item=>item.GroupId==k.Key));

            var groups = new List<string>();
            var groupTem1 = temDic.GetValueOrDefault(1)?.Select(item => { return $"{item.Name}{item.Id}"; });
            var groupTem2 = temDic.GetValueOrDefault(2)?.Select(item=> { return $"{item.Name}{item.Id}"; });
            var groupTem3 = temDic.GetValueOrDefault(3)?.Select(item=> { return $"{item.Name}{item.Id}"; });
            if(groupTem1!=null&&groupTem1.Any())
                groups.Add(string.Join(" ",groupTem1));
            if (groupTem2 != null && groupTem2.Any())
                groups.Add(string.Join(" ", groupTem2));
            if (groupTem3 != null && groupTem3.Any())
                groups.Add(string.Join(" ", groupTem3));

            var temStr = string.Join("\n",groups);

            //输出当前物品
            Console.WriteLine($"\n"+temStr);

            Console.WriteLine("请输入你要移除的编号(以逗号分隔,按Enter键结束):");

            PlayerOperate();
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="str"></param>
        public void PlayerOperate()
        {
            //输入结束捕捉
            var str = Console.ReadLine().Trim();//去掉输入的空格

            var inputs = new List<int>();

            //校验输入格式
            try
            {
                if (str.Contains(","))
                {
                    inputs = str.Split(",").Select(item => int.Parse(item)).ToList();
                }
                else
                {
                    inputs.Add(int.Parse(str));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("请输入正确格式! 如:\n1,2,3");
                PlayerOperate();
            }

            //校验输入规则
            var toDelArticles = _modelArticles.Where(item=>inputs.Contains(item.Id));
            var groupItem = toDelArticles.Select(item=>item.GroupId).Distinct();
            if(groupItem.Count()>1)
            {
                Console.WriteLine($"Warning:只能在同一行选择您想要抽取的{_articleName}。请重新输入");
                PlayerOperate();
            }

            //移除
            var toDelArticleIds = toDelArticles.Select(item=>item.Id);
            _modelArticles.RemoveAll(item => toDelArticleIds.Contains(item.Id));

            //判断游戏是否结束
            if (_modelArticles.Count() == 1)
            {
                Console.WriteLine("\n---Game Over, You Win!---");
                return;//返回,跳出操作
            }

            Console.WriteLine("操作成功，该下一个玩家操作!");

            //重新渲染
            Rendering();
        }
    }
}
