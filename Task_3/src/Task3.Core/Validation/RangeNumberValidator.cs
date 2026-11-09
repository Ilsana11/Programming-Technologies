using Task3.Core.Settings;

namespace Task3.Core.Validation;
/// <summary>
/// Проверка числа на соответсвие диапазону
/// </summary>
public class RangeNumberValidator : INumberValidator
{
    private readonly GameSettings _settings;

    public RangeNumberValidator(GameSettings settings)
    {
        _settings = settings;
    }
    public int? Validate(string? input)
    {
        // Если не получилось перевести текст в число - возвращаем null
        if (!int.TryParse(input, out int value))
        {
            return null;
        }

        // Если число вне диапазона - возвращаем null
        if(value < _settings.MinNumber || value > _settings.MaxNumber)
        {
            return null;
        }
        return value;
    }
}
