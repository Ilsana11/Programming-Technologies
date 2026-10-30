
using BankAccounts.Core.Accounts;

// Проценты на долг (для линии кредита)
namespace BankAccounts.Core.MonthEnd;
public class InterestNegaitveBalanceRule : IMonthEndRule
{
    private readonly decimal _rate;
    public InterestNegaitveBalanceRule(decimal rate)
    {
        _rate = rate;
    }

    public void Apply(IAccountOperations account, DateTime asOf)
    {
        if (account.Balance < 0)
        {
            account.Withdraw(-account.Balance * _rate, asOf, "Charge monthly interest");
        }
    }
}
