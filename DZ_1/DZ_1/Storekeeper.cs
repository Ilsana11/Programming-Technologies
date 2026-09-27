namespace DZ_1
{
    /// <summary>
    /// Представление кладовщика
    /// </summary>
    public class Storekeeper //Кладовщик
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        /// <summary>
        /// смена
        /// </summary>
        public string Shift { get; set; }
        /// <summary>
        /// опыт
        /// </summary>
        public int Experience { get; set; } 

        public bool IsMorningShift {get { return Shift == "Утренняя"; } }

        /// <summary>
        /// Возращает строковое представление кладовщика 
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"{FullName} ({Experience} лет опыта) ";
        }
    }
}
