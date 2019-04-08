using System.Collections.Generic;
using MerchantsGuideToGalaxy.Core.CommandProcessor;
using MerchantsGuideToGalaxy.Core.CommandProcessor.Symbols;
using NUnit.Framework;
using static System.String;

namespace MerchantsGuideToGalaxy.Test
{
    internal class LexTest
    {
        [Test]
        public void CanGetSymbolForOperatorsKeywords()
        {
            const string sentence = Keywords.Operators.Is;

            var lex = new Lex();
            lex.Init(sentence);

            var symbol = lex.GetNextSymbol();

            Assert.IsNotNull(symbol);
            Assert.AreEqual(SymbolKind.Operator, symbol.Kind);
        }

        [Test]
        public void CanGetSymbolForQualifiersKeywords()
        {
            const string sentence = Keywords.Qualifiers.QueryCommandQualifier;

            var lex = new Lex();
            lex.Init(sentence);

            var symbol = lex.GetNextSymbol();

            Assert.IsNotNull(symbol);
            Assert.AreEqual(SymbolKind.QueryQualifier, symbol.Kind);
        }

        [Test]
        public void CanGetSymbolForRomanKeywords()
        {
            var keywords = new List<string>
            {
                Keywords.RomanSymbols.I,
                Keywords.RomanSymbols.V,
                Keywords.RomanSymbols.X,
                Keywords.RomanSymbols.L,
                Keywords.RomanSymbols.C,
                Keywords.RomanSymbols.D,
                Keywords.RomanSymbols.M,
            };

            var sentence = Join(" ", keywords);

            var lex = new Lex();
            lex.Init(sentence);

            var symbol = lex.GetNextSymbol();
            var symbolsCount = 0;

            while (symbol != null)
            {
                Assert.AreEqual(SymbolKind.RomanSymbol, symbol.Kind);

                symbol = lex.GetNextSymbol();
                symbolsCount++;
            }

            Assert.AreEqual(keywords.Count, symbolsCount);
        }

        [Test]
        public void CanGetSymbolForStatementsKeywords()
        {
            const string sentence = Keywords.Statements.How;

            var lex = new Lex();
            lex.Init(sentence);

            var symbol = lex.GetNextSymbol();

            Assert.IsNotNull(symbol);
            Assert.AreEqual(SymbolKind.Statement, symbol.Kind);
        }

        [Test]
        public void CanGetSymbolForSubStatementsKeywords()
        {
            var keywords = new List<string>
            {
                Keywords.SubStatements.Many,
                Keywords.SubStatements.Much
            };

            var sentence = Join(" ", keywords);

            var lex = new Lex();
            lex.Init(sentence);

            var symbol = lex.GetNextSymbol();
            var symbolsCount = 0;

            while (symbol != null)
            {
                Assert.AreEqual(SymbolKind.SubStatemant, symbol.Kind);

                symbol = lex.GetNextSymbol();
                symbolsCount++;
            }

            Assert.AreEqual(keywords.Count, symbolsCount);
        }

        [Test]
        public void CanGetSymbolForConstantDeclaration()
        {
            const string sentence = "hello";

            var lex = new Lex();
            lex.Init(sentence);

            var symbol = lex.GetNextSymbol();

            Assert.AreEqual(SymbolKind.Constant, symbol.Kind);
        }

        [Test]
        public void CanGetSymbolForClassifierAndUnitDeclaration()
        {
            const string sentence = "one Banana is 32 Reais";

            var lex = new Lex();
            lex.Init(sentence);

            lex.GetNextSymbol(); //skip one
            var classifier = lex.GetNextSymbol();
            lex.GetNextSymbol(); //skip is
            lex.GetNextSymbol(); //skip 32
            var unit = lex.GetNextSymbol();

            Assert.AreEqual(SymbolKind.Classifier, classifier.Kind);
            Assert.AreEqual(SymbolKind.Unit, unit.Kind);
        }

        [Test]
        public void CanGetSymbolForClassifierAndUnitOnQuery()
        {
            const string sentence = "how many Reais is one Banana ?";

            var lex = new Lex();
            lex.Init(sentence);

            lex.GetNextSymbol(); //skip how
            lex.GetNextSymbol(); //skip many
            var unit = lex.GetNextSymbol();
            lex.GetNextSymbol(); //skip is
            lex.GetNextSymbol(); //skip one
            var classifier = lex.GetNextSymbol();

            Assert.AreEqual(SymbolKind.Classifier, classifier.Kind);
            Assert.AreEqual(SymbolKind.Unit, unit.Kind);
        }
    }
}