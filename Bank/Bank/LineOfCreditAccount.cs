namespace Bank;

/// <summary>
/// Класс: кредитный счёт с разрешённым отрицательным балансом.
/// Начисляет проценты при отрицательном балансе и штраф за превышение лимит
/// </summary>
public class LineOfCreditAccount:BankAccount
{
    /// <summary>
    /// Конструктор: создаёт кредитный счёт с заданным кредитным лимитом
    /// </summary>
    /// <param name="name">Имя владельца счёта</param>
    /// <param name="initialBalance">Начальный баланс счета</param>
    /// <param name="creditLimit">
    /// Кредитный лимит — максимально допустимая отрицательная сумма на счёте
    /// </param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
        :base(name, initialBalance, -creditLimit)
    {

    }

    /// <summary>
    /// Метод (override): выполняет операции конца месяца —
    /// начисляет проценты, если баланс отрицательный
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge monthly interest"); // Начислять ежемесячные проценты
        }
    }

    /// <summary>
    /// Метод (override, protected): определяет штраф за превышение кредитного лимита
    /// </summary>
    /// <param name="isOverdrawn">Признак того, что баланс выйдет за кредитный лимит</param>
    /// <returns>
    /// Транзакцию со штрафом <c>-20</c>, если лимит превышен, иначе <c>null</c>
    /// </returns>
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;

    //protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    //{
    //     return isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;
    //}
       

}
