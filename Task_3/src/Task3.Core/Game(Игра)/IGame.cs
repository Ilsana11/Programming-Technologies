using Task3.Core.Events;

namespace Task3.Core.Game;
/// <summary>
/// Контракт для любой игры
/// </summary>
public interface IGame
{
    /// <summary>
    /// Метод, запуска игры
    /// </summary>
    void Run();

    /// <summary>
    /// Этот метод нужен, чтобы подписывать слушателей на события
    /// </summary>
    void Subscribe(IGameListener listener);
}
