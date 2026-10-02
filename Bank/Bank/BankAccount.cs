using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank;

// BankAccount потомок класса object 
public class BankAccount
{
    private readonly decimal _minimumBalance;
    private List<Transaction> _allTransactions = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance 
    {
        get
        {
            //Начал с нуля → прошёлся по всем транзакциям →
            //сложил все суммы → получил текущий баланс.
            decimal balance = 0;
            foreach( var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }

    private static int s_accountNumberSeed = 1000000000;
    public BankAccount(string name, decimal initialBalance): this(name, initialBalance, 0) 
    {

        
    }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        //Balance = initialBalance; //this.Balance = initialBalance;
        
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        _minimumBalance = minimumBalance;
        if(initialBalance > 0)
        {
            MakeDeposite(initialBalance, DateTime.UtcNow, " initial balance");
        }
        
    }
    public void MakeDeposite(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException (nameof(amout),"Amount must be positive");
        }

        var deposite = new Transaction(amout, date, note);
        _allTransactions.Add(deposite);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);

        if(overdraftTransaction is not null)
        {
            _allTransactions.Add(overdraftTransaction);
        }


        //if (amount <= 0)
        //{
        //    throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        //}
        //if (Balance - amount < _minimumBalance)
        //{
        //    throw new InvalidOperationException("Not sufficient money for this wirhdrawal");
        //}

        //var wirhdrawal = new Transaction(-amount, date, note);
        //_allTransactions.Add(wirhdrawal);

    }
    // protected - модификатор доступа, который означает,
    // что это метод можно вызвать только из текущего дочернего класса
    // клиент (внешний код) данный метод вызвать мне может)
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if(isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
        }
        else
        {
            // default содержит значение по умолчанию, так как тип возвращаемого значения - ссылочный, то 
            // default = null
            return default; // return null;
        }
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach(var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" + $"{item.Date.ToShortDateString()}\t" + $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }

    // Ключевое слово virtual позволяет в дочернем классе предоставить
    // другую реализацию этого метода PerformMonthAndTransactions
    public virtual void PerformMonthAndTransactions()
    {

    }

    // Переорпеделяем метод базового класса - класса object 
    // ToString - возвращает строку с информацией об объекте 
    public override string ToString()
    {
        return $"Owner: {Owner}\t account number: {Number}\t (тип счета {GetType()})";
    }
}
