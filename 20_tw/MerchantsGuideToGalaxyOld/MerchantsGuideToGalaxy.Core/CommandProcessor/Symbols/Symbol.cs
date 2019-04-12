using System;

namespace MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols
{
    public class Symbol
    {
        public SymbolKind Kind { get; }
        public string Name { get; }

        public Symbol(string name, SymbolKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            return obj != null
                && obj.GetType() == GetType()
                && ((Symbol)obj).Name == Name;
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Name;
        }

        public double ToDouble()
        {
            if (!double.TryParse(Name, out var result))
                throw new Exception("Symbol is not a valid double");

            return result;
        }
    }
}
