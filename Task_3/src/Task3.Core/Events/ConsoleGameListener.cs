using Task3.Core.Output;
using Task3.Core.Game;
namespace Task3.Core.Events;
/// <summary>
/// Слушатель, который выводит события в консоль
/// </summary>
public sealed class ConsoleGameListener : IGameListener
{
    private readonly IOutput _output;
    public ConsoleGameListener(IOutput output)
    {
        _output = output;
    }

    public void OnFail(object? sender, FailEventArgs e)

    {
        _output.WriteLine($"Вы проиграли. Заданное число было: {e.Number}");
    }

    public void OnMove(object? sender, MoveEventArgs e)
    {
        if (e.Result == GuessResult.Greater)
        {
            _output.WriteLine("Ваше число больше");
        }
        else if (e.Result == GuessResult.Less)
        {
            _output.WriteLine("Ваше число меньше");
        }
    }

    public void OnWin(object? sender, WinEventArgs e)
    {
        _output.WriteLine($"Поздравляю, вы угадали за {e.Attempts} попыток");
    }
}
