using System.Collections.Generic;
using MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToGalaxy.Core.CommandProcessor.Commands
{
    public class ConstantDeclarationCommand: Command
    {
        public ConstantDeclarationCommand(IReadOnlyList<Symbol> symbols) : base(symbols)
        {
        }
    }
}
