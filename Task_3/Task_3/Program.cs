using Task3.Core.Events;
using Task3.Core.Game;
using Task3.Core.Input;
using Task3.Core.Numbers;
using Task3.Core.Output;
using Task3.Core.Settings;
using Task3.Core.Stats;
using Task3.Core.Validation;

namespace Task3.Console;
internal class Program
{
    static void Main(string[] args)
    { 
        // Создаем ввод и вывод
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();

        // Получаем настройки от пользователя, какую сложность он выбрал
        ISettingsProvider settingsProvider = new ConsoleSettingsProvider(input, output);
        GameSettings settings = settingsProvider.GetSettings();

        // Создаем зависимости для игры
        INumberGenerator generator = new RandomNumberGenerator();
        INumberValidator validator = new RangeNumberValidator(settings);

        // Настраиваем сохранение статистики
        string filePath = "stats.txt";
        StatisticsStorage storage = new StatisticsStorage(filePath);
        IGameStatistics stats = storage.Load();

        // Собираем игру
        IGame game = new GuessGame(generator, input, output, validator, stats, settings);

        // Подписываем слушателя на события
        var listener = new ConsoleGameListener(output);
        game.Subscribe(listener);
        // Запуск игры
        game.Run();

        // Сохраняем статистику 
        storage.Save(stats);
    }
}