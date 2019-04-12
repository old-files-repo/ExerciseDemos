using System;

namespace MerchantsGuideToGalaxy.Core.Exceptions
{
    public class ParsingException: Exception
    {
        public ParsingException(string message) : base(message)
        {
        }
    }
}
