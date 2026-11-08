namespace Task3.Core.Stats;
// Контракт для сбора статистики 
public interface IGameStatistics
{
    /// <summary>
    /// Запоминает игру с таким числом попыток
    /// </summary>
    /// <param name="attempts">попытки</param>
    void RegisterGame(int attempts);

    /// <summary>
    /// Минимальное число попыток
    /// </summary>
    int Min {  get; }

    /// <summary>
    /// Максимальное число попыток
    /// </summary>
    int Max { get; }

    /// <summary>
    /// Среднее число попыток
    /// </summary>
    double Average { get; }

    /// <summary>
    /// Количество сыгранных игр
    /// </summary>
    int GamesPlayed { get; }
}
