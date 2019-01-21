namespace DecoratorPattern
{
    public class Mocha : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage) => _beverage = beverage;

        public override string Description => $"{_beverage.Description}, Mocha";

        public override double Cost()
        {
            return .20 + _beverage.Cost();
        }
    }

    public class Whip : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Whip(Beverage beverage) => this._beverage = beverage;

        public override string Description => $"{_beverage.Description}, Whip";

        public override double Cost()
        {
            return .15 + _beverage.Cost();
        }
    }
}