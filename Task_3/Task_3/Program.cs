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
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();

        ISettingsProvider settingsProvider = new ConsoleSettingsProvider(input, output);
        GameSettings settings = settingsProvider.GetSettings();

        INumberGenerator generator = new RandomNumberGenerator();
        INumberValidator validator = new RangeNumberValidator(settings);

        string filePath = "stats.txt";
        StatisticsStorage storage = new StatisticsStorage(filePath);

        IGameStatistics stats = storage.Load();

        IGame game = new GuessGame(generator, input, output, validator, stats, settings);

        game.Run();

        storage.Save(stats);
    }
}