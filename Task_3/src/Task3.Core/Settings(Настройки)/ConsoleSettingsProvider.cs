using Microsoft.Win32;
using Task3.Core.Input;
using Task3.Core.Output;
using Task3.Core.Settings_Настройки_;

namespace Task3.Core.Settings;
/// <summary>
/// Спрашивает у пользователя настройки в консоли
/// Принцип SRP
/// </summary>
public sealed class ConsoleSettingsProvider : ISettingsProvider
{
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly DifficultyRegistry _registry;
    private readonly string _statsFilePath;

    public ConsoleSettingsProvider(IInput input, IOutput output, DifficultyRegistry registry, string statsFilePath)
    {
        _input = input;
        _output = output;
        _registry = registry;
        _statsFilePath = statsFilePath;

    }

    public GameSettings? GetSettings()
    {
        while (true)
        {
            _output.WriteLine(" Главное меню ");
            _output.WriteLine("1 - Выбрать уровень сложности");
            _output.WriteLine("2 - Свои настройки");
            _output.WriteLine("3 - Показать статистику из файла");
            _output.WriteLine("4 - Выйти из игры");
            _output.Write("Ваш выбор: ");

            string? choice = _input.ReadLine();

            switch (choice)
            {
                case "1":
                    GameSettings? presetSettings = ChoosePresetDifficulty();
                    if (presetSettings != null)
                    {
                        return presetSettings;
                    }
                    break; 

                case "2":
                    var custom = new CustomDifficulty(_input, _output);
                    return custom.CreateSettings();

                case "3":
                    ShowStats();
                    break; 

                case "4":
                    _output.WriteLine("Выход из игры. Сау бол");
                    return null;

                default:
                    _output.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    private GameSettings? ChoosePresetDifficulty()
    {
        while (true)
        {
            _output.WriteLine("Выбор сложности");

            // Показываем только первые 3 (базовые) сложности
            // _registry.All содержит [Easy, Medium, Hard, Custom]. Берем первые 3.
            var presets = _registry.All.Take(3).ToList();

            int index = 1;
            foreach (var level in presets)
            {
                _output.WriteLine($"{index} - {level.Name} ({level.Description})");
                index++;
            }
            _output.WriteLine("0 - Назад в главное меню");
            _output.Write("Ваш выбор: ");

            string? choice = _input.ReadLine();

            if (choice == "0")
            {
                return null; 
            }

            if (int.TryParse(choice, out int number))
            {
                IDifficulty? level = _registry.GetByNumber(number);
                if (level != null && number <= presets.Count)
                {
                    _output.WriteLine($"Выбрана сложность: {level.Name}");
                    return level.CreateSettings();
                }
            }

            _output.WriteLine("Неверный выбор. Попробуйте снова.");
        }
    }

    private void ShowStats()
    {
        if (File.Exists(_statsFilePath))
        {
            _output.WriteLine("Статистика из файла");
            foreach (string line in File.ReadAllLines(_statsFilePath))
            {
                _output.WriteLine(line);
            }
        }
        else
        {
            _output.WriteLine("Файл статистики пока пуст. Сыграйте первую игру.");
        }
    }
}
