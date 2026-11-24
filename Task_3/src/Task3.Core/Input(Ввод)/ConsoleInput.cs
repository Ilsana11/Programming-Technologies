namespace Task3.Core.Input;
/// <summary>
/// Чтение ввода с консоли
/// </summary>
public sealed class ConsoleInput : IInput
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}
