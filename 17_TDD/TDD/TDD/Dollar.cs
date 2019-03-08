namespace TDD
{
    public class Dollar
    {
        public int Amount { get; private set; }

        public Dollar(int amount)
        {
            Amount = amount;
        }

        public void Times(int multipler)
        {
            Amount *= multipler;
        }

        public override bool Equals(object e)
        {
            var dollar = (Dollar) e;
            return Amount== dollar.Amount;
        }
    }
}