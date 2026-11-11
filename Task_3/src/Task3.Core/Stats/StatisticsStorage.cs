namespace Task3.Core.Stats;
/// <summary>
/// Сохраняет статистику в тектовый файл
/// </summary>
public sealed class StatisticsStorage : IStatisticsStorage
{
    private readonly string _path;

    public StatisticsStorage(string path)
    {
        _path = path;
    }
    public IGameStatistics Load()
    {
        var stats = new GameStatistics();
        if(!File.Exists(_path))
        {
            return stats; // Если файла нет, возвращаем пустоту
        }

        try
        {
            string[] lines = File.ReadAllLines(_path);
            if (lines.Length >= 4)
            {
                int total = int.Parse(lines[0]);
                int games = int.Parse(lines[1]);
                int min = int.Parse(lines[2]);
                int max = int.Parse(lines[3]);

                stats.Restore(total, games, min, max);
            }
        }
        catch
        {

        }

        return stats;
    }

    public void Save(IGameStatistics statistics)
    {
        string[] lines =
        {
            statistics.TotalAttempts.ToString(),
            statistics.GamesPlayed.ToString(),
            statistics.Min.ToString(),
            statistics.Max.ToString()
        };

        File.WriteAllLines(_path, lines);
    }
}
