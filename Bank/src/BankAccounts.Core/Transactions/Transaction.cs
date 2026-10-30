namespace BankAccounts.Core.Transactions;

// Рекард
// Простой DTO (data transfer object(объект для передачи информации): сумма, дата, примечание
public sealed record Transaction(decimal Amount, DateTime Date, string Note);

