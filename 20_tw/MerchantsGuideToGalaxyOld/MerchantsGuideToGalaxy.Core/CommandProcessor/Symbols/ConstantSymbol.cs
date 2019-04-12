namespace MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols
{
    public class ConstantSymbol: Symbol
    {
        public ConstantSymbol(string name)
            : base(name, SymbolKind.Constant)
        {}
    }
}
