using System.Collections.Generic;
using MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToGalaxy.Core.CommandProcessor.Commands
{
    public class ClassifierDeclarationCommand: Command
    {
        public ClassifierDeclarationCommand(IReadOnlyList<Symbol> symbols) : base(symbols)
        {
        }
    }
}
