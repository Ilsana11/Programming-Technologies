namespace Task3.Core.Players_Игроки_;
/// <summary>
/// Контракт фаторизации
/// Принцип ISP
/// </summary>
public interface IPlayerProvider
{
    Player? GetPlayer();
}
