namespace Task3.Core.Settings;
/// <summary>
/// Готовые настройки для каждого уровня сложности
/// </summary>
public static class DifficultyPresets
{
    public static GameSettings Get(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => new GameSettings { MinNumber = 1, MaxNumber = 10, MaxInputAttempts = 5 },
            Difficulty.Medium => new GameSettings { MinNumber = 1, MaxNumber = 100, MaxInputAttempts = 3 },
            Difficulty.Hard => new GameSettings { MinNumber = 1, MaxNumber = 1000, MaxInputAttempts = 2 },

            _ => new GameSettings()
        };
    }
}
