namespace DecoratorPatternDemos
{
    public abstract class Drink
    {
        public virtual string Description { get; set; } = "Unknown";

        public abstract double Cost();
    }

    public abstract class Decorator : Drink
    {
        public abstract override string Description { get; }
    }

    public class Milk : Decorator
    {
        private readonly Drink _drink;
        public Milk(Drink drink)
        {
            _drink = drink;
        }

        public override string Description => $"{_drink.Description}, Mocha";

        public override double Cost()
        {
            return 1.1 + _drink.Cost();
        }
    }
}