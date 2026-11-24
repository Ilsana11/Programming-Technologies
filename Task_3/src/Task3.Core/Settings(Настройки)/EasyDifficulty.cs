using Task3.Core.Settings;

namespace Task3.Core.Settings_Настройки_;
/// <summary>
/// Лёгкий уровень: 1-10, 5 попыток
/// </summary>
public sealed class EasyDifficulty : IDifficulty
{
    public string Name => "Легкий";

    public string Description => " от 1 до 10, 5 попыток";

    public GameSettings CreateSettings() => new()
    {
        MinNumber = 1,
        MaxNumber = 10,
        MaxInputAttempts = 5
    };
}
