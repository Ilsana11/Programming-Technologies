namespace Task3.Core.Input;
/// <summary>
/// // Контракт для чтения ввода
/// Принцип DIP
/// </summary>
public interface IInput
{
    /// <summary>
    /// // Читает строку. ? - может вернуть null (пустоту)
    /// </summary>
    string? ReadLine();
}
