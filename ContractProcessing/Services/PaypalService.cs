using ContractProcessing.Interfaces;

namespace ContractProcessing.Services
{
    public sealed class PaypalService : IPaymentService
    {
        private double _simpleInterestFee;
        public double SimpleInterestFee { get => _simpleInterestFee; }

        private double _paymentFee;
        public double PaymentFee { get => _paymentFee; }

        public PaypalService()
        {
            _simpleInterestFee = 0.01;
            _paymentFee = 0.02;
        }

        public double PaymentRateValue(double amount)
        {
            return amount * PaymentFee;
        }

        public double SimpleRateValue(double amount, int installmentNumber)
        {
            return amount * installmentNumber * SimpleInterestFee;
        }
    }
}
