namespace DZ_1
{
    /// <summary>
    /// Представляет секцию склада
    /// </summary>
    public class Section // секция
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// область
        /// </summary>
        public int Area { get; set; } 
        
        public bool IsBig { get {return Area > 200; } }
        
        /// <summary>
        /// Возвращает строковое представление секции 
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"{Name} ({Area} м^2)";
        }
    }
}
