namespace DecoratorPatternDemos
{
    public sealed class Coffee : Drink
    {
        public override string Description { get; set; } = "Coffee";

        public override double Cost()
        {
            return 10;
        }
    }
}