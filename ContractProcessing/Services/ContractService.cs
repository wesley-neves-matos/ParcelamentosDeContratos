using ContractProcessing.Entities;
using ContractProcessing.Exceptions;
using ContractProcessing.Interfaces;

namespace ContractProcessing.Services
{
    public class ContractService
    {
        public double TotalValue { get; set; }
        public int InstallmentsNumber { get; set; }
        public IPaymentService PaymentService { get; private set; }

        public ContractService(double totalValue, int installmentsNumber, IPaymentService paymentService)
        {
            TotalValue = totalValue;
            InstallmentsNumber = installmentsNumber;
            PaymentService = paymentService;
        }

        public void ContractProcessing(Contract contract)
        {
            for (int installmentNumber = 1; installmentNumber <= InstallmentsNumber; installmentNumber++)
            {
                DateTime dueDate = contract.Date.AddMonths(installmentNumber);
                double amount = CalculateInstallmentValue(installmentNumber);

                contract.AddInstallment(new Installment(dueDate, amount));
            }
        }

        private double CalculateInstallmentValue(int installmentNumber)
        {
            if (IsInstallmentValid(installmentNumber))
                throw new ContractException("Número de parcela inválido!");

            double baseValue = InstallmentBaseValue();
            double amount = baseValue + PaymentService.SimpleRateValue(baseValue, installmentNumber);
            amount += PaymentService.PaymentRateValue(amount);
            return amount;
        }

        private bool IsInstallmentValid(int installmentNumber)
        {
            return installmentNumber > InstallmentsNumber || installmentNumber <= 0;
        }

        private double InstallmentBaseValue()
        {
            return TotalValue / InstallmentsNumber;
        }
    }
}
