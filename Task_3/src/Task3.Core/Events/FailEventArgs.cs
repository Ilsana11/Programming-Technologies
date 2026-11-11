namespace Task3.Core.Events;
/// <summary>
/// Данные события: игрок проиграл
/// </summary>
public sealed class FailEventArgs
{
    /// <summary>
    /// Какое число загадано
    /// </summary>
    public int Number {  get; init; }
}
