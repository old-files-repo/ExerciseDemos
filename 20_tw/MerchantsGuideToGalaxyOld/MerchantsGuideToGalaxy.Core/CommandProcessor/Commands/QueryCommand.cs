using System.Collections.Generic;
using MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols;

namespace MerchantsGuideToGalaxy.Core.CommandProcessor.Commands
{
    public class QueryCommand : Command
    {
        public QueryCommand(IReadOnlyList<Symbol> symbols) : base(symbols)
        {
        }
    }
}
