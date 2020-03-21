using System.Web;
using SimpleMvc.Web.Controllers;

namespace SimpleMvc.Web
{
    /// <summary>
    /// 模拟MVC程序的单一入口
    /// </summary>
    public class Index : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // 获取Controller名称
            var controllerName = context.Request.QueryString["c"];
            // 声明IControoler接口-根据Controller Name找到对应的Controller
            IController controller = null;

            if (string.IsNullOrEmpty(controllerName))
            {
                controllerName = "home";
            }

            switch (controllerName.ToLower())
            {
                case "home":
                    controller = new HomeController();
                    break;
                case "product":
                    controller = new ProductController();
                    break;
                default:
                    controller = new HomeController();
                    break;
            }

            controller.Execute(context);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}