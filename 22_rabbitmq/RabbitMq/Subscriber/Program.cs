using System;
using EasyNetQ;
using Messages;

namespace Subscriber
{
    class Program
    {
        public static void Main(string[] args)
        {
            var connStr = "host=127.0.0.1;virtualHost=EDCVHOST;username=admin;password=123456";

            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                bus.Subscribe<TextMessage>("my_test_subscriptionid", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        public static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}