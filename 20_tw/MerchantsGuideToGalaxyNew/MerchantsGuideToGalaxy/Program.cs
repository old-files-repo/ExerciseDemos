using System;
using MerchantsGuideToGalaxy.Core.CommandProcessor;

namespace MerchantsGuideToGalaxy
{
    internal class Program
    {
        private static void Main()
        {
            var interpreter = new LineInterpreter();

            while (true)
            {
                Console.Write("Hello Galaxy Merchant, how can I help you? ");
                var sentence = Console.ReadLine();

                if (sentence == "exit") break;

                var result = interpreter.ParseAndExecute(sentence);
                Console.WriteLine(result.ResultText);
            }
        }
    }
}
