using Task3.Core.Input;
using Task3.Core.Output;

namespace Task3.Core.Settings;
/// <summary>
/// Спрашивает у пользователя настройки в консоли
/// </summary>
public sealed class ConsoleSettingsProvider : ISettingsProvider
{
    private readonly IInput _input;
    private readonly IOutput _output;

    public ConsoleSettingsProvider(IInput input, IOutput output)
    {
        _input = input;
        _output = output;
    }

    public GameSettings GetSettings()
    {
        _output.WriteLine("Выберите уровень сложности");
        _output.WriteLine("1 - Легкий (1-10, 5 попыток)");
        _output.WriteLine("2 - Средний (1-100, 3 попытки)");
        _output.WriteLine("3 - Сложный (1-1000, 2 попытки)");
        _output.Write("Ваш выбор:");

        string? choice = _input.ReadLine();

        Difficulty diff = choice switch
        {
            "1" => Difficulty.Easy,
            "3" => Difficulty.Hard,
            _ => Difficulty.Medium,
        };

        _output.WriteLine($"Выбрана сложность: {diff}");
        return DifficultyPresets.Get(diff);
    }
}
