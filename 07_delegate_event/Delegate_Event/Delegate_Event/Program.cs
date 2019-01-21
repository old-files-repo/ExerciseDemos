using System;
using Delegate_Event;

namespace Delegate_Event
{
    class Program
    {
        private delegate int Transformer(int x);
        public delegate T Transformers<T>(T arg);

        static void Main(string[] args)
        {
            Transformer t1 = Square;
            Transformers<int> t2 = Square;
            t1 += Add;
            t1 -= Add;
            var answer = t1(5);

            //Demo1 demo1=new Demo1();
            //demo1.Run();
            Demo2 demo2 = new Demo2();
            demo2.Run();
            //MainEntryPoint.Start();

            Console.WriteLine("Hello World!" + answer);
            Console.ReadKey();
        }

        static int Square(int x) => x * x;
        static int Add(int x) => x + x;

          private static void OnFallsIll(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        }
    }

    public class Event
    {
        public delegate int AddChangeHandler(int x);
        public class Broadcaster
        {
            public event AddChangeHandler handler;
        }

        static int Square(int x) => x * x;

        public event EventHandler<FallsIllEventArgs> FallsIll;
        protected virtual void OnFallsIll(FallsIllEventArgs e)
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs("China Beijing"));
        }
    }

    public class FallsIllEventArgs : EventArgs
    {
        public readonly string Address;

        public FallsIllEventArgs(string address)
        {
            this.Address = address;
        }
    }
}
