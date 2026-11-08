namespace Task3.Core.Settings;
/// <summary>
/// Настройки игры
/// </summary>
public sealed class GameSettings
{
    /// <summary>
    /// Минимальное число диапазона
    /// </summary>
    public int MinNumber { get; init; } = 1;

    /// <summary>
    /// Максимальное число диапазона
    /// </summary>
    public int MaxNumber { get; init; } = 100;

    /// <summary>
    /// Максимальное количество попыток ввода
    /// </summary>
    public int MaxInputAttempts { get; init; } = 3;
}
