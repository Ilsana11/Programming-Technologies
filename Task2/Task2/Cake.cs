namespace Task2;

/// <summary>
/// Торт - блюдо, которое можно подать гостю
/// </summary>
public class Cake: Dish, IServable
{
    /// <summary>
    /// Количество слоев торта
    /// </summary>
    public int Layers { get; set; }

    /// <summary>
    /// Является ли торт большим
    /// </summary>
    public bool IsBigCake => Layers >= 3;

    /// <summary>
    /// Подать торт гостю
    /// </summary>
    public void Serve()
    {
        Console.WriteLine($"{Name} served");
    }

    /// <summary>
    /// Создаёт торт с идентификатором, названием, ценой и количеством слоёв
    /// </summary>
    public Cake(int id, string name, decimal price, int layers)
        :base(id, name, price)
    {
        Layers = layers;
    }

    /// <summary>
    /// Приготовь торт
    /// </summary>
    public override void Cook()
    {
        Console.WriteLine($"{Name} cooked");
    }

    /// <summary>
    /// Возвращает строковое представление
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return base.ToString() + $", layers: {Layers}";
    }
}
