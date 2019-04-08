namespace MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols
{
    public class UnitSymbol: Symbol
    {
        public double Factor { get; set; }

        public UnitSymbol(string name)
            : base(name, SymbolKind.Unit)
        {
        }
    }
}
