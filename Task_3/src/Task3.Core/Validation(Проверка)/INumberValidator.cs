namespace Task3.Core.Validation;
/// <summary>
/// Контракт для проверки чисел
/// </summary>
public interface INumberValidator
{
    /// <summary>
    /// Проверяет текст. Если число верное, возвращает его, иначе null
    /// </summary>
    int? Validate(string? input);
}
