using System;

namespace DecoratorPatternDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            Drink drink = new Coffee();
            drink =new Milk(drink);
            drink =new Milk(drink);

            Console.WriteLine(drink.Description +"    "+ drink.Cost());
            Console.ReadKey();
        }
    }
}
