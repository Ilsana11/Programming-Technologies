using Task3.Core.Settings;

namespace Task3.Core.Settings_Настройки_;
/// <summary>
/// Сложный уровень: 1-1000, 2 попытки
/// Принцип SRP
/// </summary>
internal class HardDifficulty : IDifficulty
{
    public string Name => "Сложный";

    public string Description => " от 1 до 1000, 2 попытки";

    public GameSettings CreateSettings() => new()
    {
        MinNumber = 1,
        MaxNumber = 1000,
        MaxInputAttempts = 2
    };
}
