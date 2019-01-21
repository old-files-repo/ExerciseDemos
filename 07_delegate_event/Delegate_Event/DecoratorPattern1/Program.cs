using System;
using System.IO;
using System.Threading.Tasks;

namespace DecoratorPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 在当前目录创建按一个 test.txt 文件
            using (Stream s = new FileStream("test.txt", FileMode.Create))
            {
                Console.WriteLine(s.CanRead); // True
                Console.WriteLine(s.CanWrite); // True
                Console.WriteLine(s.CanSeek); // True
                s.WriteByte(101);
                s.WriteByte(102);
                byte[] block = { 1, 2, 3, 4, 5 };
                s.Write(block, 0, block.Length); // 写 5 字节
                Console.WriteLine(s.Length); // 7
                Console.WriteLine(s.Position); // 7
                s.Position = 0; // 回到开头位置
                Console.WriteLine(s.ReadByte()); // 101
                Console.WriteLine(s.ReadByte()); // 102
                // 从block数组开始的地方开始read:
                Console.WriteLine(s.Read(block, 0, block.Length)); // 5
                // 假设最后一次read返回 5, 那就是在文件结尾, 所以read会返回0:
                Console.WriteLine(s.Read(block, 0, block.Length)); // 0
            }

            Task.Run(AsyncDemo).GetAwaiter().GetResult();
        }

        public static async Task AsyncDemo()
        {
            using (Stream s = new FileStream("test.txt", FileMode.Create))
            {
                byte[] block = { 1, 2, 3, 4, 5 };
                await s.WriteAsync(block, 0, block.Length);
                s.Position = 0;
                Console.WriteLine(await s.ReadAsync(block, 0, block.Length));
            }
        }
    }
}
