using System;
using Xunit;
using Xunit.Abstractions;

namespace Hospital.Tests
{
    public class PatientShould : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Patient _patient;
        //private readonly GameStateFixture _gameStateFixture;
        private readonly Sut _sut;

        public PatientShould(ITestOutputHelper output,
            GameStateFixture gameStateFixture,
            Sut sut)
        {
            _output = output;
            _sut = sut;
            _output.WriteLine("正在创建 Boss Enemy");
            _patient = gameStateFixture.Patient;
        }

        [Fact(Skip = "不需要跑这个测试")]
        public void HaveHeartBeatWhenNewSkip()
        {


            var patient = _patient;

            Assert.True(patient.IsNew);
        }

        [Fact]
        public void HaveHeartBeatWhenNew()
        {


            var patient = _patient;

            Assert.True(patient.IsNew);
        }

        [Fact]
        [Trait("Category", "Enemy")]
        public void CalculateFullName()
        {

            var p = _patient;
            Assert.Equal("Nick Carter", p.FullName);
        }

        public void Dispose()
        {
            _output.WriteLine($"正在清理玩家{_patient.FullName}");
        }

        [Fact]
        public void TakeZeroDamage()
        {
            _sut.TakeDamage(0);
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void TakeSmallDamage()
        {
            _sut.TakeDamage(1);
            Assert.Equal(99, _sut.Health);
        }

        [Fact]
        public void TakeMediumDamage()
        {
            _sut.TakeDamage(50);
            Assert.Equal(50, _sut.Health);
        }

        [Fact]
        public void TakeMinimum1Damage()
        {
            _sut.TakeDamage(101);
            Assert.Equal(1, _sut.Health);
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }
    }

    public class Sut
    {
        public int Health { get; set; }

        public void TakeDamage(int num)
        {
            Health = 100 - num;
        }
    }
}
