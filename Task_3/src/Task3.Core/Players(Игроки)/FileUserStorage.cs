namespace Task3.Core.Players_Игроки_;
/// <summary>
/// Реализация хранилища
/// Принцип SRP
/// </summary>
public sealed class FileUserStorage : IUserStorage
{
    private readonly string _filePath = "users.txt";
    public void Add(string name)
    {
        File.AppendAllText(_filePath, name + "\n");
    }

    public bool Exists(string name)
    {
        if (!File.Exists(_filePath)) return false;
        string[] users = File.ReadAllLines(_filePath);
        foreach (string user in users)
        {
            if (user.ToLower() == name.ToLower()) return true;
        }
        return false;
    }
}
