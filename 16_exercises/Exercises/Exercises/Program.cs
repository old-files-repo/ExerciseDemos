using System;
using System.Collections.Generic;

namespace Exercises
{
    class Program
    {
        //step1  定义委托
        public delegate void ShowCity(string cityName);

        //Action<string> ShowCity;

        delegate int Transfermer(int i);

        static void Foo<T>(T x)
        {
        }

        static void Bar<T>(Action<T> x)
        {
        }

        static int number = 3;

        public static Func<int, int> _multiplier = (x) => number * x;

        //step2  声明与委托对应的方法
        public static void ShowCityFunction(string str)
        {
            Console.WriteLine(str);
        }

        static void Count(int i)
        {
            Console.WriteLine(i);

            if (i < 0)
            {
                return;
            }
            else
            {
                Count(i - 1);
            }
        }

        static private List<int> _numArray = new List<int>();

        static IEnumerable<int> GetAllEvenNumber()
        {
            for (int i = 1; i <= 100; i++)
            {
                _numArray.Add(i); //把1到100保存在集合当中方便操作
            }

            foreach (int num in _numArray)
            {
                if (num % 2 == 0) //判断是不是偶数
                {
                    yield return num; //返回当前偶数

                }
            }
        }

        public static void Main(string[] args)
        {
            number = 10;

            Console.WriteLine(_multiplier(3));

            Bar<int>((int x) => Foo(x));
            Bar<int>(Foo);

            //step3  实例化委托
            ShowCity show = ShowCityFunction;

            //step4  实例化委托
            show.Invoke("su zhou");
            show("shang hai");

            Transfermer square = (x) => x * x;

            Console.WriteLine(square(2));

            try
            {
                Console.WriteLine("A");
                goto Here;
            }
            catch (Exception e)
            {
                Console.WriteLine("B");
                throw;
            }
            finally
            {
                Console.WriteLine("C");
            }

        Here:
            Console.WriteLine("here");

            foreach (char c in "hello world!")
            {
                Console.WriteLine(c);
            }

            using (var enumerator = "hello world!".GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var ele = enumerator.Current;
                    Console.WriteLine(ele);
                }
            }

            var instance = Singleton.Instance;

            int? a = 5;
            int? b = 1;
            bool cc = a < b;

            dynamic duck=new Duck();
            duck.Quack();

            Console.ReadKey();
        }
    }

    public class Singleton
    {
        private static volatile Singleton _instance;
        private static readonly object LockObject = new object();

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (LockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }

                    }
                }

                return _instance;
            }
        }
    }

    public class Duck
    {
        public void Quack()
        {
            Console.WriteLine("Quack");
        }
    }

}
