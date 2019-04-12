using System;

namespace MerchantsGuideToGalaxy.Core.Exceptions
{
    public class InvalidRomanNumberException: Exception
    {
        public InvalidRomanNumberException(string message) : base(message)
        {
        }
    }
}
