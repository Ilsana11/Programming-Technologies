namespace Task3.Core.Stats;
/// <summary>
/// Контракт для сохранения и загрузки статистики
/// </summary>
public  interface IStatisticsStorage
{
    IGameStatistics Load();
    void Save(IGameStatistics statistics);
}
