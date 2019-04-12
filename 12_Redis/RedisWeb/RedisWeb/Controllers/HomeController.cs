using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RedisWeb.Models;
using StackExchange.Redis;

namespace RedisWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDistributedCache _distributedCache;
        private readonly IDatabase _db;

        public HomeController(
            IConnectionMultiplexer redis,
            IDistributedCache distributedCache)
        {
            _redis = redis;
            _distributedCache = distributedCache;

            _db = redis.GetDatabase();
        }

        public IActionResult Index()
        {
            //_db.StringSet("fullName", "yuzhao");

            //var name = _db.StringGet("fullName");

            var value = _distributedCache.Get("name-key");
            if (value == null)
            {
                var obj = new Dictionary<string, string>
                {
                    ["FirstName"] = "Nike",
                    ["LastName"] = "Carter"
                };
                var str = JsonConvert.SerializeObject(obj);
                byte[] encoded = Encoding.UTF8.GetBytes(str);

                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3000));

                _distributedCache.Set("name-key", encoded, options);
                return View("Index", obj.ToString());
            }
            else
            {
                var str = Encoding.UTF8.GetString(value);
                var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(str);
                return View("Index", obj.ToString());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
