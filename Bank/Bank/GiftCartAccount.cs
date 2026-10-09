namespace Bank;

/// <summary>
/// Класс: счёт-копилка для накоплений на подарок.
/// Позволяет ежемесячно вносить фиксированную сумму
/// </summary>
public class GiftCartAccount: BankAccount//наследование
{
    /// <summary>
    /// Поле: фиксированная сумма ежемесячного пополнения.
    /// Значение <c>0</c> означает, что автопополнение отключено
    /// </summary>
    private readonly decimal _monthlyDeposit = 0m;

    // monthlyDeposit - параметр по умолчанию принимает 0,
    // при создании объекта new GiftCartAccount("Yana", 1000) => monthlyDeposit = 0
    // new GiftCartAccount("Yana", 1000, 5000); => monthlyDeposit = 5000

    /// <summary>
    /// Конструктор: создаёт счёт-копилку с заданной суммой ежемесячного пополнения
    /// </summary>
    /// <param name="name">Имя владельца счёта</param>
    /// <param name="initialBalance">Начальный баланс счёта</param>
    /// <param name="monthlyDeposit">
    /// Сумма ежемесячного пополнения. По умолчанию <c>0</c> — автопополнение отключено
    /// </param>
    public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
        :base(name, initialBalance) 
        => _monthlyDeposit = monthlyDeposit;

    /// <summary>
    /// Метод (override): выполняет операции конца месяца —
    /// вносит ежемесячное пополнение, если оно задано
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposite(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }
    /// <summary>
    /// Метод (override): возвращает строковое представление счёта-копилки
    /// </summary>
    /// <returns>
    /// Строка с данными базового счёта и суммой ежемесячного пополнения
    /// </returns>
    public override string ToString()
    {
        return base.ToString() + $"monthly deposit: {_monthlyDeposit}";
    }
}
