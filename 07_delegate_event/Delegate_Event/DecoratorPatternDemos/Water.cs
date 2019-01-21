namespace DecoratorPatternDemos
{
    public sealed class Water : Drink
    {
        public override string Description { get; set; } = "Water";

        public override double Cost()
        {
            return 2;
        }
    }
}