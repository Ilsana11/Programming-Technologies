using BankAccounts.Core.Accounts;

// Проценты на положительный баланс выше порога (для процентного счета)
namespace BankAccounts.Core.MonthEnd;

public class InterestOnPositiveBalanceRule : IMonthEndRule
{
    private readonly decimal _rate;
    private readonly decimal _thresold;// пороговый уровень
    public InterestOnPositiveBalanceRule(decimal rate, decimal thresold)
    {
        _rate = rate;
        _thresold = thresold;
    }
    public void Apply(IAccountOperations account, DateTime asOf)
    {
        if(account.Balance > _thresold)
        {
            account.Deposit(account.Balance*_rate, asOf, "apply monthly interest");
        }
    }
}
