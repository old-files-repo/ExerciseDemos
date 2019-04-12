using System;

namespace MerchantsGuideToGalaxy.Core.Exceptions
{
    public class DuplicatedDeclarationException: Exception
    {
        public DuplicatedDeclarationException(string message) : base(message)
        {
        }
    }
}
