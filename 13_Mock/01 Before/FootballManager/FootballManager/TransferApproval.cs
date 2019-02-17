using System;

namespace FootballManager
{
    public class TransferApproval
    {
        private readonly IPhysicalExamination _physicalExamination;
        public bool PlayerHealthCheck { get; private set; }

        public TransferApproval(IPhysicalExamination physicalExamination)
        {
            _physicalExamination = physicalExamination ??
                throw new ArgumentException(nameof(physicalExamination));

            _physicalExamination.HealthChecked += PhysicalExamationHealthChecked;
        }

        private void PhysicalExamationHealthChecked(object sender, EventArgs e)
        {
            PlayerHealthCheck = true;
        }

        private const int RemainingTotalBudget = 300; // 剩余预算(百万)

        public TransferResult Evaluate(TransferApplication transfer)
        {
            if (_physicalExamination.MedicalRoom.Status.IsAvailable == "停用")
            {
                return TransferResult.Postponed;
            }

            bool isHealthy;
            try
            {
                _physicalExamination.IsHealthy(transfer.PlayerAge, transfer.PlayerStrength
                    , transfer.PlayerSpeed, out isHealthy);
            }
            catch (Exception e)
            {
                return TransferResult.Postponed;
            }

            if (!isHealthy)
            {
                _physicalExamination.PhysicalGrade = PhysicalGrade.Failed;
                return TransferResult.Rejected;
            }
            else
            {
                if (transfer.PlayerAge < 25)
                {
                    _physicalExamination.PhysicalGrade = PhysicalGrade.Superb;
                }
                else
                {
                    _physicalExamination.PhysicalGrade = PhysicalGrade.Passed;
                }
            }
            var totalTransferFee = transfer.TransferFee + transfer.ContractYears * transfer.AnnualSalary;
            if (RemainingTotalBudget < totalTransferFee)
            {
                return TransferResult.Rejected;
            }
            if (transfer.PlayerAge < 30)
            {
                return TransferResult.Approved;
            }
            if (transfer.IsSuperStar)
            {
                return TransferResult.ReferredToBoss;
            }
            return TransferResult.Rejected;
        }
    }
}
