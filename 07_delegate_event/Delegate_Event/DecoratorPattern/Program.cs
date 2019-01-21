using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var beverage = new Espresso();
            Console.WriteLine($"{beverage.Description} $ {beverage.Cost()}");

            Beverage beverage2 = new HouseBlend();
            var a1 = beverage2.Description;
            var a11 = beverage2.Cost();
            beverage2 = new Mocha(beverage2);
            var a2 = beverage2.Description;
            var a22 = beverage2.Cost();
            beverage2 = new Mocha(beverage2);
            var a3 = beverage2.Description;
            var a33 = beverage2.Cost();
            beverage2 = new Whip(beverage2);
            var a4 = beverage2.Description;
            var a44 = beverage2.Cost();
            Console.WriteLine($"{beverage2.Description} $ {beverage2.Cost()}");
            Console.ReadKey();
        }
    }
}
