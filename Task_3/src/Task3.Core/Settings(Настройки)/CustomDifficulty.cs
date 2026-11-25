using Task3.Core.Input;
using Task3.Core.Output;
using Task3.Core.Settings;

namespace Task3.Core.Settings_Настройки_;
/// <summary>
/// Пользовательская сложность: игрок сам вводит диапазон и количество попыток
/// Принцип OCP
/// </summary>
public sealed class CustomDifficulty : IDifficulty
{
    private readonly IInput _input;
    private readonly IOutput _output;
    public string Name => "Свои настройки";

    public string Description => "Вы сами задаете диапазон и попытки";

    public CustomDifficulty(IInput input, IOutput output)
    {
        _input = input;
        _output = output;
    }

    public GameSettings CreateSettings()
    {
        var settings = new GameSettings();

        // 1. Спрашиваем минимальное число
        while (true)
        {
            _output.Write("Введите минимальное число (от -1000000): ");
            if (int.TryParse(_input.ReadLine(), out int min))
            {
                settings.MinNumber = min;
                break;
            }
            _output.WriteLine("Ошибка! Введите целое число.");
        }

        // 2. Спрашиваем максимальное число (проверяем, чтобы оно было больше минимального)
        while (true)
        {
            _output.Write($"Введите максимальное число (больше {settings.MinNumber}): ");
            if (int.TryParse(_input.ReadLine(), out int max) && max > settings.MinNumber)
            {
                settings.MaxNumber = max;
                break;
            }
            _output.WriteLine($"Ошибка! Введите число больше {settings.MinNumber}.");
        }

        // 3. Спрашиваем количество попыток
        while (true)
        {
            _output.Write("Введите количество попыток (больше 0): ");
            if (int.TryParse(_input.ReadLine(), out int attempts) && attempts > 0)
            {
                settings.MaxInputAttempts = attempts;
                break;
            }
            _output.WriteLine("Ошибка! Количество попыток должно быть больше 0.");
        }

        return settings;
    }
}

