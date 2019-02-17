using System;
using FootballManager;
using Moq;
using Xunit;

namespace XUnitTest
{
    public class TransferApprovalShouldBeUse
    {
        [Fact]
        public void PhysicalGrade_ShouldPassed_When_TransferringSuperStar()
        {
            var physicalExamination = new Mock<IPhysicalExamination>
            {
                DefaultValue = DefaultValue.Mock
            };

            //physicalExamination.Setup(x => x.MedicalRoom.Status.IsAvailable).Returns("Í£ÓÃ");

            physicalExamination.SetupProperty(x => x.PhysicalGrade, PhysicalGrade.Passed);

            bool healthy = true;
            physicalExamination.Setup(x =>
                x.IsHealthy(It.Is<int>(age => age < 16), It.IsAny<int>(), It.IsAny<int>(), out healthy))
                .Throws<Exception>();

            var approval = new TransferApproval(physicalExamination.Object);

            var emreTransfer = new TransferApplication
            {
                PlayerName = "111",
                PlayerAge = 15,
                PlayerStrength = 80,
                PlayerSpeed = 80
            };

            var result = approval.Evaluate(emreTransfer);

            Assert.Equal(result, TransferResult.Postponed);
        }

        [Fact]
        public void Should_PlayerHealth_Checked_When_TransferringSuperStar()
        {
            var physicalExamination = new Mock<IPhysicalExamination>
            {
                DefaultValue = DefaultValue.Mock
            };

            //physicalExamination.Setup(x => x.MedicalRoom.Status.IsAvailable).Returns("Í£ÓÃ");

            physicalExamination.SetupProperty(x => x.PhysicalGrade, PhysicalGrade.Passed);

            bool healthy = true;
            physicalExamination.Setup(x =>
                    x.IsHealthy(It.Is<int>(age => age < 16), It.IsAny<int>(), It.IsAny<int>(), out healthy))
                .Raises(x => x.HealthChecked += null, EventArgs.Empty);

            var approval = new TransferApproval(physicalExamination.Object);

            var emreTransfer = new TransferApplication
            {
                PlayerName = "111",
                PlayerAge = 15,
                PlayerStrength = 80,
                PlayerSpeed = 80
            };

            var result = approval.Evaluate(emreTransfer);

            //physicalExamination.Raise(x => x.HealthChecked += null, EventArgs.Empty);

            Assert.True(approval.PlayerHealthCheck);
        }
    }
}
