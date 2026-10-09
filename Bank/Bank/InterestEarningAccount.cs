namespace Bank;

/// <summary>
/// Класс: счёт с начислением процентов на остаток.
/// Проценты начисляются, если баланс превышает порог
/// </summary>
public class InterestEarningAccount:BankAccount
{
    /// <summary>
    /// Конструктор: создаёт счёт с начислением процентов
    /// </summary>
    /// <param name="name">Имя владельца счёта</param>
    /// <param name="initialBalance">Начальный баланс счёта</param>
    public InterestEarningAccount(string name, decimal initialBalance)
        : base (name, initialBalance)
    {


    }

    // override позволяет в дочернем классе определить новую реализацию
    // этого метода PerformMonthAndTransactions
    /// <summary>
    /// Метод (override): выполняет операции конца месяца —
    /// начисляет проценты, если баланс превышает <c>500</c>
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposite(interest, DateTime.UtcNow, "Apply month interest");
        }

    }
}
