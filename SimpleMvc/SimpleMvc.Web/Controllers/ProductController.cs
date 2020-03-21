using System.Web;

namespace SimpleMvc.Web.Controllers
{
    public class ProductController : IController
    {
        private HttpContext currentContext;

        // action 1 : Index
        public void Index()
        {
            currentContext.Response.Write("Product Index Success!");
        }

        // action 2 : Add
        public void Add()
        {
            currentContext.Response.Write("Product Add Success!");
        }

        public void Execute(HttpContext context)
        {
            currentContext = context;
            // 默认Action名称
            string actionName = "index";
            // 获取Action名称
            if (!string.IsNullOrEmpty(context.Request["action"]))
            {
                actionName = context.Request["action"];
            }

            switch (actionName.ToLower())
            {
                case "index":
                    this.Index();
                    break;
                case "add":
                    this.Add();
                    break;
                default:
                    this.Index();
                    break;
            }
        }
    }
}