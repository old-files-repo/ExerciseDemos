using System;
using System.Collections.Generic;

namespace SimpleMvc.Web
{
    public class Global : System.Web.HttpApplication
    {
        private static IList<string> Routes;

        protected void Application_Start(object sender, EventArgs e)
        {
            Routes = new List<string>();
            // http://www.edisonchou.cn/controller/action
            Routes.Add("{controller}/{action}");
            // http://www.edisonchou.cn/controller
            Routes.Add("{controller}");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // 模拟路由字典
            IDictionary<string, string> routeData = new Dictionary<string, string>();

            // 将URL与路由表中每一条记录进行匹配
            foreach (var item in Routes)
            {
                var executePath = Request.AppRelativeCurrentExecutionFilePath; //// 获得当前请求的参数数组
                // 如果没有参数则执行默认配置
                if (string.IsNullOrEmpty(executePath) || executePath.Equals("~/"))
                {
                    executePath += "/home/index";
                }

                var executePathArray = executePath.Substring(2).Split(new[] {'/'},
                    StringSplitOptions.RemoveEmptyEntries);
                var routeKeys = item.Split(new[] {'/'},
                    StringSplitOptions.RemoveEmptyEntries);
                if (executePathArray.Length == routeKeys.Length)
                {
                    for (int i = 0; i < routeKeys.Length; i++)
                    {
                        routeData.Add(routeKeys[i], executePathArray[i]);
                    }

                    // 入口一：单一入口 Index.ashx
                    //Context.RewritePath(string.Format("~/Index.ashx?c={0}&a={1}", routeData["{controller}"], routeData["{action}"]));
                    // 入口二：指定MvcHandler进行后续处理
                    Context.RemapHandler(new MvcHandler(routeData));
                    // 只要满足一条规则就跳出循环匹配
                    break;
                }
            }
        }
    }
}