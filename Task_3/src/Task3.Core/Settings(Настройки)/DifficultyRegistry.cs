using Task3.Core.Input;
using Task3.Core.Output;

namespace Task3.Core.Settings_Настройки_;
/// <summary>
/// Реестр доступных уровней сложности.
/// Хранит список IDifficulty и умеет выбирать по номеру.
/// </summary>
public sealed class DifficultyRegistry
{
    private readonly IReadOnlyList<IDifficulty> _levels;

    public DifficultyRegistry(IInput input, IOutput output)
    {
        _levels = new IDifficulty[]
        {
            new EasyDifficulty(),
            new MediumDifficulty(),
            new HardDifficulty(),
            new CustomDifficulty(input, output)
        };
    }

    /// <summary>
    /// Количество доступных уровней
    /// </summary>
    public int Count => _levels.Count;

    /// <summary>
    /// Возвращает уровень по номеру (1-based), либо null если номер вне диапазона
    /// </summary>
    public IDifficulty? GetByNumber(int number)
    {
        if (number < 1 || number > _levels.Count)
        {
            return null;
        }
        return _levels[number - 1];
    }

    /// <summary>
    /// Перечисление всех уровней (для вывода меню)
    /// </summary>
    public IEnumerable<IDifficulty> All => _levels;
}
