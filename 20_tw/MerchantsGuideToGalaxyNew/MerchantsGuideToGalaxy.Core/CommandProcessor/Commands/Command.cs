using System.Collections.Generic;
using MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToGalaxy.Core.CommandProcessor.Commands
{
    public abstract class Command
    {
        public IReadOnlyList<Symbol> Symbols { get; set; }

        protected Command(IReadOnlyList<Symbol> symbols)
        {
            Symbols= symbols;
        }

        public override string ToString()
        {
            return string.Join(" ", Symbols);
        }
    }
}
