using System;
using FootballManager;
using Moq;
using Xunit;

namespace XUnitTest
{
    public class TransferApprovalShould
    {
        [Fact]
        public void Approval_YoungCheapPlayer_Transfer()
        {
            var physicalExamination = new Mock<IPhysicalExamination>
            {
                DefaultValue = DefaultValue.Mock
            };

            //physicalExamination.Setup(x =>
            //    x.IsHealthy(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            //    .Returns(true);
            physicalExamination.Setup(x =>
                    x.IsHealthy(
                        It.Is<int>(age => age < 30),
                        It.IsIn<int>(80, 85, 90),
                        It.IsInRange<int>(75, 99, Range.Inclusive)))
                    .Returns(true);

            var approval = new TransferApproval(physicalExamination.Object);

            var emreTransfer = new TransferApplication
            {
                PlayerName = "111",
                PlayerAge = 22,
                PlayerStrength = 80,
                PlayerSpeed = 80
            };

            var result = approval.Evaluate(emreTransfer);

            Assert.Equal(TransferResult.Approved, result);
        }

        [Fact]
        public void Reject_When_NonSuperstarOldPlayer()
        {
            var physicalExamination = new Mock<IPhysicalExamination>(MockBehavior.Default);

            bool healthy = false;
            physicalExamination.Setup(x =>
                x.IsHealthy(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),out healthy));

            var approval = new TransferApproval(physicalExamination.Object);

            var emreTransfer = new TransferApplication
            {
                PlayerName = "111",
                PlayerAge = 22,
                PlayerStrength = 80,
                IsSuperStar = false,
                PlayerSpeed = 80
            };

            var result = approval.Evaluate(emreTransfer);

            Assert.Equal(TransferResult.Rejected, result);
        }

        [Fact]
        public void Approval_IsMedicalRoomAvailable_False_YoungCheapPlayer_Transfer()
        {
            var physicalExamination = new Mock<IPhysicalExamination>();

            physicalExamination.Setup(x => x.MedicalRoom.Status.IsAvailable).Returns("Í£ÓÃ");

            physicalExamination.Setup(x =>
                x.IsHealthy(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var approval = new TransferApproval(physicalExamination.Object);

            var emreTransfer = new TransferApplication
            {
                PlayerName = "111",
                PlayerAge = 22,
                PlayerStrength = 80,
                PlayerSpeed = 80
            };

            var result = approval.Evaluate(emreTransfer);

            Assert.Equal(TransferResult.Postponed, result);
        }

        [Fact]
        public void PhysicalGrade_ShouldPassed_When_TransferringSuperStar()
        {
            var physicalExamination = new Mock<IPhysicalExamination>
            {
                DefaultValue = DefaultValue.Mock
            };

            //physicalExamination.Setup(x => x.MedicalRoom.Status.IsAvailable).Returns("Í£ÓÃ");

            physicalExamination.SetupProperty(x => x.PhysicalGrade);

            bool healthy=true;
            physicalExamination.Setup(x =>
                x.IsHealthy(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out healthy));

            var approval = new TransferApproval(physicalExamination.Object);

            var emreTransfer = new TransferApplication
            {
                PlayerName = "111",
                PlayerAge = 33,
                PlayerStrength = 80,
                PlayerSpeed = 80
            };

            var result = approval.Evaluate(emreTransfer);

            Assert.Equal(PhysicalGrade.Passed, physicalExamination.Object.PhysicalGrade);
        }
    }
}
