using Task3.Core.Settings;

namespace Task3.Core.Settings_Настройки_;
/// <summary>
/// Средний уровень: 1-100, 3 попытки
/// Принцип SRP
/// </summary>
internal class MediumDifficulty : IDifficulty
{
    public string Name => "Средний";

    public string Description => "от 1 до 100, 3 попытки";

    public GameSettings CreateSettings() => new()
    {
        MinNumber = 1,
        MaxNumber = 100,
        MaxInputAttempts = 3
    };
}
