namespace Task3.Core.Output;
/// <summary>
/// Выво текста в консоль
/// </summary>
public sealed class ConsoleOutput : IOutput
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void Write(string message)
    {
        Console.Write(message);
    }
}
