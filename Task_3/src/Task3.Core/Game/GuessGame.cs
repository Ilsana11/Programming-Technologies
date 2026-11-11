using Task3.Core.Events;
using Task3.Core.Input;
using Task3.Core.Numbers;
using Task3.Core.Output;
using Task3.Core.Settings;
using Task3.Core.Stats;
using Task3.Core.Validation;

namespace Task3.Core.Game;
/// <summary>
///  Ядро игры. Управляет ходом
/// </summary>
public sealed class GuessGame : IGame
{
    private readonly INumberGenerator _generator;
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly INumberValidator _validator;
    private readonly IGameStatistics _stats;
    private readonly GameSettings _settings;

    public event EventHandler<MoveEventArgs>? MoveMade;
    public event EventHandler<WinEventArgs>? Won;
    public event EventHandler<FailEventArgs>? Failed;


    public GuessGame(INumberGenerator generator, IInput input, IOutput output, INumberValidator validator,
        IGameStatistics stats, GameSettings settings)
    {
        _generator = generator;
        _input = input;
        _output = output;
        _validator = validator;
        _stats = stats;
        _settings = settings;
    }

    public void Subscribe(IGameListener listener)
    {
        MoveMade += listener.OnMove;
        Won += listener.OnWin;
        Failed += listener.OnFail;
    }

    public void Run()
    {
        bool playAgain = true;

        while (playAgain == true)
        {
            PlaySingleGame();
            _output.Write("Хотите сыграть еще раз? y/n:");

            string? input = _input.ReadLine();
            if (input != "y")
            {
                playAgain = false;
            }

        }
        PrintStats();
    }

    private void PlaySingleGame() // Сыграть одну игру
    {
        int number = _generator.Generate(_settings.MinNumber, _settings.MaxNumber);

        int attempts = 0;

        while (true)
        {
            attempts++;
            GuessResult result = ReadGuess(number);

            if (result == GuessResult.Fail)
            {
                // Событие проигрыша
                Failed?.Invoke(this, new FailEventArgs {Number = number});
                return;
            }

            // Событие хода
            MoveMade?.Invoke(this, new MoveEventArgs { Result = result, Attempt = attempts });

            if (result == GuessResult.Win)
            {
                // Событие победы
                _stats.RegisterGame(attempts);
                Won?.Invoke(this, new WinEventArgs { Attempts = attempts});
                return;
            }
        }

    }

    private GuessResult ReadGuess(int number)
    {
        for (int i = 0; i < _settings.MaxInputAttempts; i++)
        {
            _output.WriteLine($"Введите число от {_settings.MinNumber} до {_settings.MaxNumber}");

            string? input = _input.ReadLine();
            int? guess = _validator.Validate(input);

            if (guess == null)
            {
                continue; // Если ввели мусор, тратим попытку ввода
            }

            int userNumber = guess.Value;

            if (userNumber > number)
            {
                return GuessResult.Greater;
            }
            if (userNumber < number)
            {
                return GuessResult.Less;
            }
            return GuessResult.Win;
        }
        return GuessResult.Fail;
    }

    private void PrintStats()
    {
        _output.WriteLine($"Мин: {_stats.Min}, Макс {_stats.Max}, Среднее: {_stats.Average:F2}");
    }



}
