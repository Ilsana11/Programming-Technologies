namespace Task3.Core.Players_Игроки_;
/// <summary>
/// Хранилище аккаунтов
/// Принцип DIP
/// </summary>
public interface IUserStorage
{
    bool Exists(string name);
    void Add(string name);
}
