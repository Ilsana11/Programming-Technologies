namespace Task3.Core.Numbers;
/// <summary>
/// Контракт для генератора чисел
/// </summary>
internal interface INumberGenerator
{
    /// <summary>
    /// Загадывает число в диапозоне от min до max
    /// </summary>
    int Generate(int min, int max);
}
