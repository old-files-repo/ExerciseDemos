namespace MerchantsGuideToGalaxy.Core.Exceptions
{
    public class InvalidRomanSymbolException: InvalidRomanNumberException
    {
        public InvalidRomanSymbolException(string message) : base(message)
        {
        }
    }
}
