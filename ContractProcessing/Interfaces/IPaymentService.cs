namespace ContractProcessing.Interfaces
{
    public interface IPaymentService
    {
        public double SimpleInterestFee { get; }
        public double PaymentFee { get; }
        public double SimpleRateValue(double amount, int installmentNumber);
        public double PaymentRateValue(double amount);
    }
}
