namespace Task3.Core.Events;
/// <summary>
/// Контракт для слушателя игры
/// </summary>
public interface IGameListener
{
    void OnMove(object? sender, MoveEventArgs e);
    void OnWin(object? sender, WinEventArgs e);
    void OnFail(object? sender, FailEventArgs e);
}
