namespace Task3.Core.Numbers;
/// <summary>
/// Генерация случайного числа
/// </summary>
public sealed class RandomNumberGenerator : INumberGenerator
{
    private readonly Random _random = new();
    public int Generate(int min, int max)
    {
        return _random.Next(min, max + 1);
    }
}
