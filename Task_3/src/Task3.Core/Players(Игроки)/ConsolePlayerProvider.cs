using Task3.Core.Input;
using Task3.Core.Output;

namespace Task3.Core.Players_Игроки_;
/// <summary>
/// Логика входа через консоль
/// Принцип DIP
/// </summary>
public sealed class ConsolePlayerProvider : IPlayerProvider
{
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly IUserStorage _userStorage;

    public ConsolePlayerProvider(IInput input, IOutput output, IUserStorage userStorage)
    {
        _input = input;
        _output = output;
        _userStorage = userStorage;
    }

    public Player? GetPlayer()
    {
        while (true)
        {
            _output.WriteLine("Вход в игру");
            _output.Write("Введите ваше имя (или оставьте пустым для выхода) : ");

            string? name = _input.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name)) return null;

            if (_userStorage.Exists(name))
            {
                _output.WriteLine($"С возвращением, {name}!");
                return new Player(name);
            }
            _output.WriteLine($"Игрока {name} нетy списке. Хотите созать аккаунт? (да/нет)");
            string? answer = _input.ReadLine()?.Trim().ToLower();
            if (answer == "да")
            {
                _userStorage.Add(name);
                _output.WriteLine($"Аккаунт {name} успешно создан!");
                return new Player(name);
            }

        }
    }
}
