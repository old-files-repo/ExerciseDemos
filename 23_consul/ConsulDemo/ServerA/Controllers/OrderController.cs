using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace ServerA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var features = ServiceLocator.ApplicationBuilder.Properties["server.Features"] as FeatureCollection;
            var address = features.Get<IServerAddressesFeature>().Addresses.First();
            return Ok($"Order From ServerA[{address}]");
        }
    }
}