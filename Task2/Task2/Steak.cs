namespace Task2;

/// <summary>
/// Стейк - блюдо, которое нельзя подавать без указания прожарки
/// Наследут Dish, не реализует IServable
/// </summary>
public class Steak: Dish
{
    /// <summary>
    /// Степень прожарки стейка
    /// </summary>
    public string Doneness { get; set; }

    /// <summary>
    /// Является ли стейк слабой прожарки
    /// </summary>
    public bool IsRare => Doneness == "rare";

    /// <summary>
    /// Создаёт стейк с идентификатором, названием, ценой и прожаркой
    /// </summary>
    public Steak (int id,string name,decimal price, string doneness)
        :base(id, name, price)
    {
        Doneness = doneness;
    }

    /// <summary>
    /// Приготовить стейк
    /// </summary>
    public override void Cook()
    {
        Console.WriteLine($"{Name} cooked");
    }

    /// <summary>
    /// Возвращает строковое представление стейка
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return base.ToString() + $", doneness: {Doneness}";
    }
}
