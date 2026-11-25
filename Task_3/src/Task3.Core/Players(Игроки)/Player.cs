namespace Task3.Core.Players_Игроки_;
/// <summary>
/// Модель игрока
/// Принцип SRP
/// </summary>
public sealed class Player
{
    public string Name { get; }
    public Player(string name)
    {
        Name = name;
    }
}
