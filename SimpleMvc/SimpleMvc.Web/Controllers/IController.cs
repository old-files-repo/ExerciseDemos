using System.Web;

namespace SimpleMvc.Web.Controllers
{
    public interface IController
    {
        void Execute(HttpContext context);
    }
}