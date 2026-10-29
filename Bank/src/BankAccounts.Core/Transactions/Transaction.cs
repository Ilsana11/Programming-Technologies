namespace BankAccounts.Core.Transactions;

// Рекард
// Простой DTO (data transfer object(объект для передачи информации): сумма, дата, примечание
public sealed class Transaction(decimal Amount, DateTime Date, string Note);

