using System.Text;

namespace Bank;

public class AuditLog
{
    /// <summary>
    /// Запись журнала аудита об одной операции
    /// </summary>
    /// <param name="AccountNumber">Номер счета</param>
    /// <param name="Type">Тип операции</param>
    /// <param name="Amount">Сумма операции</param>
    /// <param name="Date">Дата и время операции</param>
    public record Entry(string AccountNumber,string Type,decimal Amount,DateTime Date);

    /// <summary>
    /// Список всех записей журнала
    /// </summary>
    private readonly List<Entry> _entries = new();

    /// <summary>
    /// Метод: добавляет запись об операции в журнал
    /// </summary>
    /// <param name="accountNumber">Номер счета</param>
    /// <param name="type">Тип операции</param>
    /// <param name="amount">Сумма операции</param>
    /// <param name="date">Дата и время операции</param>
    /// <param name="note">Комментарии к операции</param>
    public void Log(string accountNumber, string type, decimal amount, DateTime date)
    {
        _entries.Add(new Entry(accountNumber, type, amount, date));
    }

    /// <summary>
    /// Метод возвращает все записи журнала
    /// </summary>
    /// <returns>Список записей аудита</returns>
    public IReadOnlyList<Entry> GetEntries() => _entries;

    /// <summary>
    /// Метод: формирует текстовый отчёт по журналу
    /// </summary>
    /// <returns>Строка со всеми записями журнала.</returns>
    public string GetReport()
    {
        string report = "Account\t\tType\t\tAmount\t\tDate\n";
        foreach (var e in _entries)
        {
            report += $"{e.AccountNumber}\t{e.Type}\t\t{e.Amount}\t\t" +
                      $"{e.Date.Day}.{e.Date.Month}.{e.Date.Year}\n";
        }
        return report;
    }
}
