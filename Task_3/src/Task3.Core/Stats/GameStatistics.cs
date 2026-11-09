namespace Task3.Core.Stats;
/// <summary>
/// Статистика памяти
/// </summary>
public sealed class GameStatistics : IGameStatistics
{
    private int _totalAttempts; // Сумма попыток
    private int _gamePlayed; // Сыграно игр

    public int Min {  get; private set; }
    public int Max { get; private set; }
    public int GamesPlayed => _gamePlayed;

    public double Average
    {
        get
        {
            if (_gamePlayed == 0)
            {
                return 0;
            }
            return (double)_totalAttempts / _gamePlayed;
        }
    }
    public void RegisterGame(int attempts)
    {
        _gamePlayed++;
        _totalAttempts += attempts;

        // Если это первая игра или текущее число меньше Min
        if (Min == 0 || attempts <  Min)
        {
            Min = attempts; 
        }

        if (attempts > Max)
        {
            Max = attempts;
        }
    }
}
