using System;
using System.Collections.Generic;
using Pipelines.Sockets.Unofficial;
using StackExchange.Redis;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            //重复复用，已实现IDisposable

            IDatabase db = redis.GetDatabase();//访问redis数据库

            db.StringSet(new KeyValuePair<RedisKey, RedisValue>[]
            {
                new KeyValuePair<RedisKey, RedisValue>("name1", "yu zhao1"),
                new KeyValuePair<RedisKey, RedisValue>("name2", "yu zhao2"),
                new KeyValuePair<RedisKey, RedisValue>("name3", "yu zhao3")
            });

            var names = db.StringGet(new RedisKey[]
            {
                "name1","name2","name3",
            });//通过key获取值
            var age = db.StringGet("age");

            foreach (var name in names)
            {
                Console.WriteLine($"This name in redis is : {name},age is :{age}");
            }
           
            Console.ReadKey();
        }
    }
}
