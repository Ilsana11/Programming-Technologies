namespace Task3.Core.Validation;
/// <summary>
/// Контракт для проверки чисел
/// Принцип DIP
/// </summary>
public interface INumberValidator
{
    /// <summary>
    /// Проверяет текст. Если число верное, возвращает его, иначе null
    /// </summary>
    int? Validate(string? input);
}
