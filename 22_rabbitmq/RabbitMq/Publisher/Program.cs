using System;
using EasyNetQ;
using Messages;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "host=127.0.0.1;virtualHost=EDCVHOST;username=admin;password=123456";

            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                var input = "hello rabbitmq";
                Console.WriteLine("Please enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new TextMessage
                    {
                        Text = input
                    });
                }
            }
        }
    }
}