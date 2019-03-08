using System;
using System.Linq;

namespace TDD
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[]
            {
                1,3,2,9,5,7,9,0,3,4,4,5,3
            };

            var res = Sort(arr);

            foreach (var re in res)
            {
                Console.WriteLine(re);
            }

            Console.ReadKey();
        }

        public static int[] Sort(int[] arr)
        {
            if (arr.Length < 2)
            {
                return arr;
            }

            var pivot = arr[0];
            var less = arr.Skip(1).Where(x => x <= pivot).ToArray();
            var greater = arr.Skip(1).Where(x => x > pivot).ToArray();

            return Sort(less).Concat(new[]
            {
                pivot
            }).Concat(Sort(greater)).ToArray();
        }
    }
}
