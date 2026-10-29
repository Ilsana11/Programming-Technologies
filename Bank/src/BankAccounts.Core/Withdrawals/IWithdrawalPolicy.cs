namespace BankAccounts.Core.Withdrawals;

public interface IWithdrawalPolicy
{
    //currentBalance - текущий баланс
    WithdrawalDecision Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance); 
}
