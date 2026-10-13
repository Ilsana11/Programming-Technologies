namespace Task2;

/// <summary>
/// Абстракный класс: Блюда в ресторане
/// </summary>
public abstract class Dish
{
    // readonly - Это поле можно задать только один раз
    // — при создании объекта. После этого менять нельзя»
    /// <summary>
    /// Приватное поле
    /// </summary>
    private readonly int _id;

    /// <summary>
    /// Авто-Свойство: Название блюда
    /// </summary>
    public string Name {  get; set; }
    /// <summary>
    /// Авто-Свойство: Цена блюда
    /// </summary>
    public decimal Price {  get; set; }

    /// <summary>
    /// Свойство-перечисление
    /// Категория блюда. По-умолчанию - основное блюдо
    /// </summary>
    public Course Course { get; set; } = Course.Main;
    
    /// <summary>
    /// Вычисляемое свойство
    /// Цена с учетом 10% наценки за обслуживание
    /// </summary>
    public decimal PriceWithService => Price * 1.1m;

    /// <summary>
    /// Конструктор: создает блюдо с указанным идентификатором, названием и ценой
    /// </summary>
    /// <param name="id">Идентификатор блюда</param>
    /// <param name="name">Название блюда</param>
    /// <param name="price">Цена блюда</param>
    public Dish(int id,  string name, decimal price)
    {
        _id = id;
        Name = name;
        Price = price;
    }

    /// <summary>
    /// ПЕРЕГРУЖЕННЫЙ КОНСТРУКТОР
    /// Создаёт блюдо без идентификатора и цены (id = 0, price = 0)
    /// Вызывает основной конструктор через this(...)
    /// </summary>
    /// <param name="name"></param>
    public Dish(string name) : this(0, name, 0)
    {

    }

    /// <summary>
    /// АБСТРАКТНЫЙ МЕТОД
    /// Приготовить блюдо. Реализуется наследниками
    /// </summary>
    public abstract void Cook();

    /// <summary>
    /// Возвращает строковое представление блюда
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[{GetType().Name}] {Name}, {Price}, course:{Course}";
    }

}
