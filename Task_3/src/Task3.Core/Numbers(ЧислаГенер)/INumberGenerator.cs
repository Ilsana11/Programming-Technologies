namespace Task3.Core.Numbers;
/// <summary>
/// Контракт для генератора чисел
/// </summary>
public interface INumberGenerator
{
    /// <summary>
    /// Загадывает число в диапозоне от min до max
    /// </summary>
    int Generate(int min, int max);
}
