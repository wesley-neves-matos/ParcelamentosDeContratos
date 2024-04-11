using System.Globalization;

namespace ContractProcessing.Entities
{
    public class Installment
    {
        public DateTime DueDate { get; set; }
        public double Amout { get; set; }

        public Installment(DateTime dueDate, double amout)
        {
            DueDate = dueDate;
            Amout = amout;
        }

        public override string ToString()
        {
            return $"{DueDate.ToShortDateString()} - {Amout.ToString("F2",CultureInfo.InvariantCulture)}";
        }
    }
}
