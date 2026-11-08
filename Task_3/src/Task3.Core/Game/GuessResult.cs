namespace Task3.Core.Game;
/// <summary>
/// Перечисление исходов хода (больше, меньше, победа, провал)
/// </summary>
public enum GuessResult
{
    /// <summary>
    /// Больше
    /// </summary>
    Greater,

    /// <summary>
    /// Меньше
    /// </summary>
    Less,

    /// <summary>
    /// Победа
    /// </summary>
    Win,

    /// <summary>
    /// Провал
    /// </summary>
    Fail
}
