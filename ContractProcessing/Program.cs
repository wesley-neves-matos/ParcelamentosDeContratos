using ContractProcessing.Entities;
using ContractProcessing.Services;
using System.Globalization;

Console.WriteLine("Enter contract data");

Console.Write("Number: ");
int contractNumber = int.Parse(Console.ReadLine());

Console.Write("Date (dd/MM/yyyy): ");
DateTime date = DateTime.Parse(Console.ReadLine());

Console.Write("Contract value: ");
double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Contract contract = new Contract(contractNumber, date, contractValue);

Console.Write("Enter number of installments: ");
int installmentsNumber = int.Parse(Console.ReadLine());

ContractService contractService = new ContractService(contract.TotalValue, installmentsNumber, new PaypalService());
contractService.ContractProcessing(contract);

Console.WriteLine("Installments:");
foreach (Installment installment in contract.Installments)
{
    Console.WriteLine(installment.ToString());
}

