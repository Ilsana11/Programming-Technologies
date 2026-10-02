namespace Bank;
/// <summary>
/// Тип данных, который запрещает менять состояние объекта
/// </summary>
/// <param name="Amount">сумма транзакции</param>
/// <param name="Date">дата транзакции</param>
/// <param name="Note">заметки транзакции</param>
public record Transaction(decimal Amount, DateTime Date, string Note);

 