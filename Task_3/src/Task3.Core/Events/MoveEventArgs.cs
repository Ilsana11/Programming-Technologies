using Task3.Core.Game;

namespace Task3.Core.Events;
/// <summary>
/// Данные события: сделан ход
/// </summary>
public sealed class MoveEventArgs
{
    /// <summary>
    /// Какое число ввел игрок
    /// </summary>
    public int Guess {  get; init; }

    /// <summary>
    /// Результат (больше, меньше, победа)
    /// </summary>
    public GuessResult Result { get; init; }

    /// <summary>
    /// Номер попытки
    /// </summary>
    public int Attempt { get; init; }
}
