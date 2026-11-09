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
        GameSettings settings = new GameSettings
        {
            MinNumber = 1,
            MaxNumber = 100,
            MaxInputAttempts = 3
        };

        INumberGenerator generator = new RandomNumberGenerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        INumberValidator validator = new RangeNumberValidator(settings);
        IGameStatistics stats = new GameStatistics();

        IGame game = new GuessGame(generator, input, output, validator, stats, settings);

        game.Run();
    }
}