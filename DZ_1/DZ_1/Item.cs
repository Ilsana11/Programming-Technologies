namespace DZ_1
{
    /// <summary>
    /// Представляет товар на складе
    /// </summary>
    public class Item //элемент
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// id радела
        /// </summary>
        public int SectionId { get; set; }
        /// <summary>
        /// id кладовщика
        /// </summary>
        public int StorekeeperId { get; set; }
        /// <summary>
        /// количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// цена
        /// </summary>
        public decimal Price { get; set; }

        public decimal TotalValue { get { return Price * Quantity; } }

        /// <summary>
        /// Проверяет, находится ли кол-во товара ниже заданного.
        /// </summary>
        /// <param name="threshold"> целое (низкий) пороговое значение</param>
        /// <returns></returns>
        public bool IsLowStock(int threshold) { return Quantity < threshold; } 
     
        /// <summary>
        /// Возвращает строковое представение товара
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"{Name} {Quantity} шт., {Price} руб";
        }

        /// <summary>
        /// конструктор для проверки входящих данных, чтобы были положительные
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">имя</param>
        /// <param name="sectionId"> id секции</param>
        /// <param name="storekeeperId">id кладовщика</param>
        /// <param name="quantity">количество</param>
        /// <param name="price">цена</param>
        /// <exception cref="ArgumentException"></exception>
        public Item(int id, string name, int sectionId, int storekeeperId, int quantity, decimal price)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity),"Количество должно быть больше 0");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price),"Цена не может быть отрицательной");
            }

            Id = id;
            Name = name;
            SectionId = sectionId;
            StorekeeperId = storekeeperId;
            Quantity = quantity;
            Price = price;
        }

    }
}
