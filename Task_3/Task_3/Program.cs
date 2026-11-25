using Task3.Core.Events;
using Task3.Core.Game;
using Task3.Core.Input;
using Task3.Core.Numbers;
using Task3.Core.Output;
using Task3.Core.Settings;
using Task3.Core.Settings_Настройки_;
using Task3.Core.Stats;
using Task3.Core.Validation;
using Task3.Core.Players_Игроки_;

namespace Task3;
internal class Program
{
    static void Main(string[] args)
    { 
        // Создаем ввод и вывод
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();

        // Получаем настройки от пользователя, какую сложность он выбрал
        var registry = new DifficultyRegistry(input, output);
        ISettingsProvider settingsProvider = new ConsoleSettingsProvider(input, output, registry);

        IUserStorage userStorage = new FileUserStorage();
        IPlayerProvider playerProvider = new ConsolePlayerProvider(input, output, userStorage);


        while (true)
        {
            Player? player = playerProvider.GetPlayer();
            if (player == null)
            {
                return;
            }

            string filePath = "stats_" + player.Name + ".txt";
            IStatisticsStorage storage = new StatisticsStorage(filePath);
            IGameStatistics stats = storage.Load();

            while (true)
            {
                GameSettings? settings = settingsProvider.GetSettings();
                if (settings == null)
                {
                    return; 
                }

                // Создаем зависимости для игры
                INumberGenerator generator = new RandomNumberGenerator();
                INumberValidator validator = new RangeNumberValidator(settings);

                // Собираем игру
                IGame game = new GuessGame(generator, input, output, validator, stats, settings);

                // Подписываем слушателя на события
                var listener = new ConsoleGameListener(output);
                game.Subscribe(listener);

                // Запуск игры
                game.Run();

                // Сохраняем статистику в личный файл игрока
                storage.Save(stats);

                output.WriteLine("Игра завершена. Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear(); // Очищаем консоль для удобства

            }


        }
    }
}