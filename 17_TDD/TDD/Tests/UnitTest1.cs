using System;
using TDD;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Success_When_Multiplication()
        {
            var five = new Dollar(5);
            five.Times(2);

            Assert.Equal(10, five.Amount);
        }

        [Fact]
        public void BeEueal_When_Amount_Equal()
        {
            Assert.True(new Dollar(5).Equals(new Dollar(5)));

            Assert.False(new Dollar(5).Equals(new Dollar(6)));
        }
    }
}
