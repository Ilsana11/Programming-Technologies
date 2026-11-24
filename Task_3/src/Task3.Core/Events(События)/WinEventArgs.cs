namespace Task3.Core.Events;
/// <summary>
/// Данные события: игрок победил
/// </summary>
public sealed class WinEventArgs
{
    /// <summary>
    /// За сколько попыток угадал
    /// </summary>
    public int Attempts { get; init; }
}
