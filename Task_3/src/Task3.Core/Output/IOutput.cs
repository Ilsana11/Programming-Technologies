namespace Task3.Core.Output;
/// <summary>
/// Контракт для вывода текста
/// </summary>
public interface IOutput
{
    /// <summary>
    /// печатает текст и переводит строку
    /// </summary>
    void WriteLine(string message);

    /// <summary>
    /// Печатает текст без пеервода строки (для y/n)
    /// </summary>
    void Write(string message);
}
