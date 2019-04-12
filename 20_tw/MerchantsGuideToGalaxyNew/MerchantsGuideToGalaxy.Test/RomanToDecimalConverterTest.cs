using MerchantsGuideToGalaxy.Core.Exceptions;
using MerchantsGuideToGalaxy.Core.RomanHelp;
using NUnit.Framework;

namespace MerchantsGuideToGalaxy.Test
{
    internal class RomanToDecimalConverterTest
    {
        [Test]
        public void CanConvertPrimarySymbols()
        {
            var resultForI = RomanToDecimalConverter.Convert("I");
            var resultForV = RomanToDecimalConverter.Convert("V");
            var resultForX = RomanToDecimalConverter.Convert("X");
            var resultForL = RomanToDecimalConverter.Convert("L");
            var resultForC = RomanToDecimalConverter.Convert("C");
            var resultForD = RomanToDecimalConverter.Convert("D");
            var resultForM = RomanToDecimalConverter.Convert("M");

            Assert.AreEqual(1, resultForI);
            Assert.AreEqual(5, resultForV);
            Assert.AreEqual(10, resultForX);
            Assert.AreEqual(50, resultForL);
            Assert.AreEqual(100, resultForC);
            Assert.AreEqual(500, resultForD);
            Assert.AreEqual(1000, resultForM);
        }

        [Test]
        public void CanConvertRepetitions()
        {

            var resultForIii = RomanToDecimalConverter.Convert("III");
            var resultForXxx = RomanToDecimalConverter.Convert("XXX");
            var resultForCcc = RomanToDecimalConverter.Convert("CCC");
            var resultForMmm = RomanToDecimalConverter.Convert("MMM");

            Assert.AreEqual(3, resultForIii);
            Assert.AreEqual(30, resultForXxx);
            Assert.AreEqual(300, resultForCcc);
            Assert.AreEqual(3000, resultForMmm);
        }

        [Test]
        public void CanConvertSubtractions()
        {

            var resultForIv = RomanToDecimalConverter.Convert("IV");
            var resultForIx = RomanToDecimalConverter.Convert("IX");
            var resultForXl = RomanToDecimalConverter.Convert("XL");
            var resultForXc = RomanToDecimalConverter.Convert("XC");
            var resultForCd = RomanToDecimalConverter.Convert("CD");
            var resultForCm = RomanToDecimalConverter.Convert("CM");

            Assert.AreEqual(4, resultForIv);
            Assert.AreEqual(9, resultForIx);
            Assert.AreEqual(40, resultForXl);
            Assert.AreEqual(90, resultForXc);
            Assert.AreEqual(400, resultForCd);
            Assert.AreEqual(900, resultForCm);
        }

        [Test]
        public void CanConvertAdditions()
        {

            var resultForViii = RomanToDecimalConverter.Convert("VIII");
            var resultForXiii = RomanToDecimalConverter.Convert("XIII");
            var resultForXv = RomanToDecimalConverter.Convert("XV");
            var resultForXviii = RomanToDecimalConverter.Convert("XVIII");

            Assert.AreEqual(8, resultForViii);
            Assert.AreEqual(13, resultForXiii);
            Assert.AreEqual(15, resultForXv);
            Assert.AreEqual(18, resultForXviii);
        }

        #region "I" can be subtracted from "V" and "X" only.
        [Test]
        public void ThrowsExceptionForSubstractionFaultForI()
        {

            var exceptionForL = false;
            var exceptionForC = false;
            var exceptionForD = false;
            var exceptionForM = false;

            try { RomanToDecimalConverter.Convert("IL"); }
            catch (InvalidRomanNumberException) { exceptionForL = true; }
            try { RomanToDecimalConverter.Convert("IC"); }
            catch (InvalidRomanNumberException) { exceptionForC = true; }
            try { RomanToDecimalConverter.Convert("ID"); }
            catch (InvalidRomanNumberException) { exceptionForD = true; }
            try { RomanToDecimalConverter.Convert("IM"); }
            catch (InvalidRomanNumberException) { exceptionForM = true; }

            Assert.IsTrue(exceptionForL);
            Assert.IsTrue(exceptionForC);
            Assert.IsTrue(exceptionForD);
            Assert.IsTrue(exceptionForM);
            Assert.AreEqual(4, RomanToDecimalConverter.Convert("IV"));
            Assert.AreEqual(9, RomanToDecimalConverter.Convert("IX"));
        }
        #endregion

        #region "X" can be subtracted from "L" and "C" only.
        [Test]
        public void ThrowsExceptionForSubstractionFaultForX()
        {

            var exceptionForD = false;
            var exceptionForM = false;

            try { RomanToDecimalConverter.Convert("ID"); }
            catch (InvalidRomanNumberException) { exceptionForD = true; }
            try { RomanToDecimalConverter.Convert("IM"); }
            catch (InvalidRomanNumberException) { exceptionForM = true; }

            Assert.AreEqual(11, RomanToDecimalConverter.Convert("XI"));
            Assert.AreEqual(15, RomanToDecimalConverter.Convert("XV"));
            Assert.AreEqual(20, RomanToDecimalConverter.Convert("XX"));
            Assert.AreEqual(40, RomanToDecimalConverter.Convert("XL"));
            Assert.AreEqual(90, RomanToDecimalConverter.Convert("XC"));
            Assert.IsTrue(exceptionForD);
            Assert.IsTrue(exceptionForM);
        }
        #endregion

        #region "C" can be subtracted from "D" and "M" only.
        [Test]
        public void CorrectSubstractionsForC()
        {

            Assert.AreEqual(101, RomanToDecimalConverter.Convert("CI"));
            Assert.AreEqual(105, RomanToDecimalConverter.Convert("CV"));
            Assert.AreEqual(110, RomanToDecimalConverter.Convert("CX"));
            Assert.AreEqual(150, RomanToDecimalConverter.Convert("CL"));
            Assert.AreEqual(200, RomanToDecimalConverter.Convert("CC"));
            Assert.AreEqual(400, RomanToDecimalConverter.Convert("CD"));
            Assert.AreEqual(900, RomanToDecimalConverter.Convert("CM"));
        }
        #endregion

        #region "V", "L", and "D" can never be subtracted.
        [Test]
        public void VNeverCanSubtracted()
        {

            Assert.AreEqual(6, RomanToDecimalConverter.Convert("VI"));

            var exceptionForVv = false;
            var exceptionForVx = false;
            var exceptionForVl = false;
            var exceptionForVc = false;
            var exceptionForVd = false;
            var exceptionForVm = false;

            try { RomanToDecimalConverter.Convert("VV"); }
            catch (InvalidRomanNumberException) { exceptionForVv = true; }
            try { RomanToDecimalConverter.Convert("VX"); }
            catch (InvalidRomanNumberException) { exceptionForVx = true; }
            try { RomanToDecimalConverter.Convert("VL"); }
            catch (InvalidRomanNumberException) { exceptionForVl = true; }
            try { RomanToDecimalConverter.Convert("VC"); }
            catch (InvalidRomanNumberException) { exceptionForVc = true; }
            try { RomanToDecimalConverter.Convert("VD"); }
            catch (InvalidRomanNumberException) { exceptionForVd = true; }
            try { RomanToDecimalConverter.Convert("VM"); }
            catch (InvalidRomanNumberException) { exceptionForVm = true; }

            Assert.IsTrue(exceptionForVv);
            Assert.IsTrue(exceptionForVx);
            Assert.IsTrue(exceptionForVl);
            Assert.IsTrue(exceptionForVc);
            Assert.IsTrue(exceptionForVd);
            Assert.IsTrue(exceptionForVm);
        }

        [Test]
        public void LNeverCanSubtracted()
        {

            var exceptionForLl = false;
            var exceptionForLc = false;
            var exceptionForLd = false;
            var exceptionForLm = false;

            Assert.AreEqual(51, RomanToDecimalConverter.Convert("LI"));
            Assert.AreEqual(55, RomanToDecimalConverter.Convert("LV"));
            Assert.AreEqual(60, RomanToDecimalConverter.Convert("LX"));

            try { RomanToDecimalConverter.Convert("LL"); }
            catch (InvalidRomanNumberException) { exceptionForLl = true; }
            try { RomanToDecimalConverter.Convert("LC"); }
            catch (InvalidRomanNumberException) { exceptionForLc = true; }
            try { RomanToDecimalConverter.Convert("LD"); }
            catch (InvalidRomanNumberException) { exceptionForLd = true; }
            try { RomanToDecimalConverter.Convert("LM"); }
            catch (InvalidRomanNumberException) { exceptionForLm = true; }

            Assert.IsTrue(exceptionForLl);
            Assert.IsTrue(exceptionForLc);
            Assert.IsTrue(exceptionForLd);
            Assert.IsTrue(exceptionForLm);
        }

        [Test]
        public void DNeverCanSubtracted()
        {


            var exceptionForDd = false;
            var exceptionForDm = false;

            Assert.AreEqual(501, RomanToDecimalConverter.Convert("DI"));
            Assert.AreEqual(505, RomanToDecimalConverter.Convert("DV"));
            Assert.AreEqual(510, RomanToDecimalConverter.Convert("DX"));
            Assert.AreEqual(550, RomanToDecimalConverter.Convert("DL"));
            Assert.AreEqual(600, RomanToDecimalConverter.Convert("DC"));

            try { RomanToDecimalConverter.Convert("DD"); }
            catch (InvalidRomanNumberException) { exceptionForDd = true; }
            try { RomanToDecimalConverter.Convert("DM"); }
            catch (InvalidRomanNumberException) { exceptionForDm = true; }

            Assert.IsTrue(exceptionForDd);
            Assert.IsTrue(exceptionForDm);
        }

        #endregion

        #region "D", "L", and "V" can never be repeated.
        [Test]
        public void ThrowsExceptionForRepettitionFaultForD()
        {
            Assert.Throws<InvalidRomanNumberException>(() => 
                RomanToDecimalConverter.Convert("DD"));
        }

        [Test]
        public void ThrowsExceptionForRepettitionFaultForL()
        {
            Assert.Throws<InvalidRomanNumberException>(() => 
                RomanToDecimalConverter.Convert("LL"));
        }

        [Test]
        public void ThrowsExceptionForRepettitionFaultForV()
        {
            Assert.Throws<InvalidRomanNumberException>(() =>
                RomanToDecimalConverter.Convert("VV"));
        }
        #endregion

        #region The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more.
        [Test]
        public void ThrowsExceptionForRepettitionFaultForI()
        {
            Assert.Throws<InvalidRomanNumberException>(() =>
                RomanToDecimalConverter.Convert("IIII"));
        }

        [Test]
        public void ThrowsExceptionForRepettitionFaultForX()
        {
            Assert.Throws<InvalidRomanNumberException>(() =>
                RomanToDecimalConverter.Convert("XXXX"));
        }

        [Test]
        public void ThrowsExceptionForRepettitionFaultForC()
        {
            RomanToDecimalConverter.Convert("");
            Assert.Throws<InvalidRomanNumberException>(() =>
                RomanToDecimalConverter.Convert("CCCC"));
        }

        [Test]
        public void ThrowsExceptionForRepettitionFaultForM()
        {
            Assert.Throws<InvalidRomanNumberException>(() =>
                RomanToDecimalConverter.Convert("MMMM"));
        }
        #endregion
    }
}
