using BankAccounts.Core.AccountNumbers;
using BankAccounts.Core.Factories;
using BankAccounts.Core.Statements;
using BankAccounts.Core.Time;


namespace BankAccounts.Comsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clock = new SystemClock();
            var factory = new AccountFactory(clock, new SequentialAccountNumberGenerator());
            var formatter = new TextStatementFormatter();
            var savings = factory.GreateInteresEarning("Yana", 10000m);
            savings.Deposit(100m, clock.Now, "asda");

            Console.WriteLine(formatter.Format(savings.Transactions));

        }
    }
}