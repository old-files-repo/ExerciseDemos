using System;
using System.Threading;

namespace AutoResetEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Request req = new Request();

            //这个人去干三件大事  
            Thread GetCarThread = new Thread(new ThreadStart(req.InterfaceA));
            GetCarThread.Start();

            Thread GetHouseThead = new Thread(new ThreadStart(req.InterfaceB));
            GetHouseThead.Start();

            //等待三件事都干成的喜讯通知信息  
            System.Threading.AutoResetEvent.WaitAll(req.autoEvents);

            //这个人就开心了。  
            req.InterfaceC();

            System.Console.ReadKey();
        }
    }

    public class Request
    {
        //建立事件数组  
        public System.Threading.AutoResetEvent[] autoEvents = null;

        public Request()
        {
            autoEvents = new System.Threading.AutoResetEvent[]
            {
                new System.Threading.AutoResetEvent(false),
                new System.Threading.AutoResetEvent(false)
            };
        }

        public void InterfaceA()
        {
            System.Console.WriteLine("请求A接口");

            Thread.Sleep(1000 * 2);

            autoEvents[0].Set();

            System.Console.WriteLine("A接口完成");
        }

        public void InterfaceB()
        {
            System.Console.WriteLine("请求B接口");

            Thread.Sleep(1000 * 1);

            autoEvents[1].Set();

            System.Console.WriteLine("B接口完成");
        }

        public void InterfaceC()
        {
            System.Console.WriteLine("两个接口都已经请求完，正在处理C");
        }
    }
}
