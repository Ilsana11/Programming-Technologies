namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Yana", 10000000);
            BankAccount account2 = new BankAccount("Lena", 100);

            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner} {account2.Balance} {account2.Number}");

            account1.MakeDeposite(12000, DateTime.UtcNow,";)");
            Console.WriteLine($"Balance:{account1.Balance}");

            account1.MakeWithdrawal(123, DateTime.UtcNow,";)");
            Console.WriteLine($"Balance:{account1.Balance}");

            Console.WriteLine(account1.GetAccountHistory());

            try
            {
                account2.MakeWithdrawal(10000, DateTime.UtcNow, "asda s");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                
            }

            InterestEarningAccount interest = new InterestEarningAccount("Yana", 1000);
            interest.PerformMonthAndTransactions();

            Console.WriteLine(interest.GetAccountHistory());

            LineOfCreditAccount lineofCredit = new LineOfCreditAccount("Yana", 0, 1000m);
            lineofCredit.MakeWithdrawal(500m, DateTime.UtcNow, "credit");

            GiftCartAccount giftcart = new GiftCartAccount("Yana", 1000m, 5000m);

            List<BankAccount> accounts = new List<BankAccount>();
            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(lineofCredit);
            accounts.Add(giftcart);

            foreach(BankAccount account in accounts)
            {
                Console.WriteLine(account); // == Console.WriteLine(account.ToString());
                account.PerformMonthAndTransactions();
                Console.WriteLine(account.GetAccountHistory());

            }

            lineofCredit.MakeWithdrawal(600m, DateTime.UtcNow, "credit");
            Console.WriteLine(lineofCredit.GetAccountHistory());



            // Задание 1
            var regular = new BankAccount("Reg", 20000, 0, AccountStatus.Regular);
            var premium = new BankAccount("Prem", 20000, 0, AccountStatus.Premium);
            var vip = new BankAccount("Vip", 20000, 0, AccountStatus.VIP);

            regular.PerformMonthAndTransactions();
            premium.PerformMonthAndTransactions();
            vip.PerformMonthAndTransactions();

            vip.MakeWithdrawal(1000, DateTime.UtcNow, "buy");

            Console.WriteLine("Задача 1");
            Console.WriteLine(regular.GetAccountHistory());
            Console.WriteLine(premium.GetAccountHistory());
            Console.WriteLine(vip.GetAccountHistory());


            // Задача 2
            Console.WriteLine("Задача 2");
            Console.WriteLine("AuditLog");
            Console.WriteLine(BankAccount.Audit.GetReport());


            // Задача 3
            Console.WriteLine();
            Console.WriteLine("Здача 3");

            var alice = new BankAccount("Алиса", 10000m);
            var bob = new BankAccount("Боб", 500m);
            var transferService = new Transfer();

            transferService.Execute(alice, bob, 3000m, DateTime.UtcNow, "оплата долга");

            Console.WriteLine($"После перевода: Алиса = {alice.Balance}, Боб = {bob.Balance}");
            Console.WriteLine();
            Console.WriteLine("История Алисы:");
            Console.WriteLine(alice.GetAccountHistory());
            Console.WriteLine("История Боба:");
            Console.WriteLine(bob.GetAccountHistory());

            // Неудачный перевод — недостаточно средств
            try
            {
                transferService.Execute(bob, alice, 1_000_000m, DateTime.UtcNow, "слишком много");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Ошибка перевода: {e.Message}");
            }

            // Перевод самому себе
            try
            {
                transferService.Execute(alice, alice, 100m, DateTime.UtcNow, "себе");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Ошибка перевода: {e.Message}");
            }

        }
    }
}