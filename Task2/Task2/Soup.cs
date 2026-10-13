namespace Task2;

/// <summary>
/// Класс-Наследник
/// Наследует Dish, реализует IServable
/// </summary>
public class Soup: Dish, IServable
{
    /// <summary>
    /// Является ли суп вегетарианским
    /// </summary>
    public bool IsVegeterian { get; set; }

    /// <summary>
    /// Вычисляемое свойство. Является ли суп легким
    /// </summary>
    public bool IsLight => PriceWithService < 400;

    /// <summary>
    /// Подать суп гостю
    /// </summary>
    public void Serve()
    {
        Console.WriteLine($"{Name} served");
    }

    /// <summary>
    /// Создаёт суп с идентификатором, названием, ценой и признаком вегетарианства
    /// Вызывает конструктор базового класса через base(...)
    /// </summary>
    public Soup (int id, string name, decimal price, bool isVegeterian)
        :base(id, name, price)
    {
        IsVegeterian = isVegeterian;
    }


    /// <summary>
    /// Приготовить суп
    /// </summary>
    public override void Cook()
    {
        Console.WriteLine($"{Name} cooked");
    }

    /// <summary>
    /// Возвращает строковое представление супа
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return base.ToString() + $", vegetarian: {IsVegeterian}";
    }





}
