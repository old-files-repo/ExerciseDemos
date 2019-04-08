using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedisSubscribe.Events;
using StackExchange.Redis;

namespace RedisSubscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisSub("ZEMICHumanResource", delegate (RedisValue message)
            {
                var deserializeObject = JsonConvert.DeserializeObject<Event>(message);

                var types = deserializeObject.EventType.Split('.');

                switch (types.Last())
                {
                    case "EmployeeAddedEvent":
                        var employeeAddedEvent = JsonConvert.DeserializeObject<EmployeeAddedEvent>(deserializeObject.JsonPayload);
                        //TODO：
                        Console.WriteLine("EmployeeAddedEvent");
                        return;
                    case "EmployeeAddedPublishEvent":
                        var employeeEditedEvent = JsonConvert.DeserializeObject(deserializeObject.JsonPayload, typeof(EmployeeEditedEvent));
                        //TODO：
                        Console.WriteLine("EmployeeAddedPublishEvent");
                        return;
                    case "SiteEmployeeAddedEvent":
                        var siteEmployeeAddedEvent = JsonConvert.DeserializeObject(deserializeObject.JsonPayload, typeof(SiteEmployeeAddedEvent));
                        //TODO：
                        Console.WriteLine("SiteEmployeeAddedEvent");
                        return;
                    case "SiteEmployeeEditedEvent":
                        var siteEmployeeEditedEvent = JsonConvert.DeserializeObject(deserializeObject.JsonPayload, typeof(SiteEmployeeEditedEvent));
                        //TODO：
                        Console.WriteLine("SiteEmployeeEditedEvent");
                        return;
                    default:
                        throw new Exception("不能识别的类型");
                }
            }).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        private static async Task RedisSub(string channelName, Action<RedisValue> callback)
        {
            var conn = GetManager();

            var sub = conn.GetSubscriber();
            sub.Ping();

            await sub.SubscribeAsync(channelName, (channel, message) =>
            {
                callback(message);
            });
        }

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                //connectionString = "10.10.10.66:6379";
                connectionString = "localhost:6379";
            }
            return ConnectionMultiplexer.Connect(connectionString);
        }
    }
}
