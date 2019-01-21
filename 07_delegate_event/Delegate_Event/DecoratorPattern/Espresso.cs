namespace DecoratorPattern
{
    public sealed class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }
        public override double Cost()
        {
            return 1.99;
        }
    }

    public sealed class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "HouseBlend";
        }

        public override double Cost()
        {
            return .89;
        }
    }
}