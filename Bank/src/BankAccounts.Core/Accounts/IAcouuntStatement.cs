using BankAccounts.Core.Transactions;

namespace BankAccounts.Core.Accounts;

// ISP: клиенты зависят только от того, что им реально нужно
public interface IAcouuntStatement
{
    IReadOnlyList<Transaction> Transactions { get; } 
}
