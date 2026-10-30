using BankAccounts.Core.Accounts;

namespace BankAccounts.Core.MonthEnd;

// Каждое правильно - отдельный класс. Новые правила добавляются без изменения старых (OCP, SRP)
public interface IMonthEndRule
{
    void Apply(IAccountOperations account, DateTime asOf);
}
