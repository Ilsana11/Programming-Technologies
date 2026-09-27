namespace DZ_1
{
    /// <summary>
    /// Главный класс программы
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - InMemoryRepository");
            Console.WriteLine("2 - CsvRepository");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            List<Section> sections = null;
            List<Storekeeper> storekeepers = null;
            List<Item> items = null;

            try
            {
                switch (choice)
                {
                    case "1":
                        InMemoryRepository memoryRepo = new InMemoryRepository();
                        sections = memoryRepo.GetSections();
                        storekeepers = memoryRepo.GetStorekeepers();
                        items = memoryRepo.GetItems();
                        break;

                    case "2":
                        CsvRepository csvRepo = new CsvRepository("data");
                        sections = csvRepo.GetSections();
                        storekeepers = csvRepo.GetStorekeepers();
                        items = csvRepo.GetItems();
                        break;

                    default:
                        Console.WriteLine("Неверный выбор"); return;

                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            

            Storekeeper foundStorekeeper = FindStorekeeper(storekeepers, items, "Болты М8");
            Console.Write("1. FindStorekeeper: ");
            if (foundStorekeeper != null)
            {
                Console.WriteLine(foundStorekeeper.GetInfo());
            }
            else
            {
                Console.WriteLine("не найдено");
            }

            Section foundSection = FindSection(sections, items, "Болты М8");
            Console.Write("2. FindSection: ");
            if (foundSection != null)
            {
                Console.WriteLine(foundSection.GetInfo());
            }
            else
            {
                Console.WriteLine("не найдено");
            }

            int totalQuantity = GetTotalQuantity(items);
            Console.WriteLine("3. GetTotalQuantity: " + totalQuantity + " шт.");


            List<Item> lowStockItems = GetItemsBelowThreshold(items, 100);
            Console.Write("4. GetItemsBelowThreshold(100): ");
            if (lowStockItems.Count == 0)
            {
                Console.WriteLine("нет товаров");
            }
            else
            {
                for (int i = 0; i < lowStockItems.Count; i++)
                {
                    Console.Write(lowStockItems[i].Name);
                    if(i <  lowStockItems.Count - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("5. PrintAllItems:");
            PrintAllItems(items, storekeepers, sections);

            Console.WriteLine();
            Console.WriteLine("Не найдено:");

            Storekeeper notFoundStorekeeper = FindStorekeeper(storekeepers, items, "Неизвестный товар");
            if (notFoundStorekeeper == null)
            {
                Console.WriteLine("FindStorekeeper (Неизвестный товар)  null");
            }
            else
            {
                Console.WriteLine("FindStorekeeper (Неизвестный товар) найдено");
            }


        }

        /// <summary>
        /// Поиск кладовщика, отвечающего за указанный товар
        /// </summary>
        /// <param name="storekeepers">Кладовщики</param>
        /// <param name="items">Товары</param>
        /// <param name="itemName">Название товара,для которого ищем кладовщика</param>
        /// <returns></returns>
        public static Storekeeper FindStorekeeper(List<Storekeeper> storekeepers, List<Item> items, string itemName)
        {
            if (storekeepers == null)
            {
                return null;
            }
            if (items == null)
            {
                return null;
            }

            int targetStorekeeperId = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == itemName)
                {
                    targetStorekeeperId = items[i].StorekeeperId;
                    break;
                }
            }

            if (targetStorekeeperId == 0)
            {
                return null;
            }

            for (int i = 0; i < storekeepers.Count; i++)
            {
                if (storekeepers[i].Id == targetStorekeeperId)
                {
                    return storekeepers[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Поиск раздела, в котором хранится указанный товар
        /// </summary>
        /// <param name="sections">Секции</param>
        /// <param name="items">Товары</param>
        /// <param name="itemName">Название товара, для которого ищем секцию</param>
        /// <returns></returns>
        public static Section FindSection(List<Section> sections, List<Item> items, string itemName)
        {
            if (sections == null)
            {
                return null;
            }
            if (items == null)
            {
                return null;
            }

            int targetSectionId = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == itemName)
                {
                    targetSectionId = items[i].SectionId;
                    break;
                }
            }

            if (targetSectionId == 0)
            {
                return null;
            }

            for (int i = 0; i < sections.Count; i++)
            {
                if (sections[i].Id == targetSectionId)
                {
                    return sections[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Подсчёт общего количества всех товаров на складе
        /// </summary>
        /// <param name="items">Товары</param>
        /// <returns></returns>
        public static int GetTotalQuantity(List<Item> items)
        {
            if (items == null)
            {
                return 0;
            }

            int total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                total = total + items[i].Quantity;
            }

            return total;
        }

        /// <summary>
        /// Возвращает список товаров, количество которых ниже заданного порога
        /// </summary>
        /// <param name="items">Товары</param>
        /// <param name="threshold">Целое пороговое значение</param>
        /// <returns></returns>
        public static List<Item> GetItemsBelowThreshold(List<Item> items, int threshold)
        {
            List<Item> result = new List<Item>();

            if (items == null)
            {
                return result;
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].IsLowStock(threshold))
                {
                    result.Add(items[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Печатает все товары с указанием кладовщика и раздела
        /// </summary>
        /// <param name="items">Товары</param>
        /// <param name="storekeepers">Кладовщики</param>
        /// <param name="sections">Секции</param>
        public static void PrintAllItems(List<Item> items, List<Storekeeper> storekeepers, List<Section> sections)
        {
            if (items == null)
            {
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Item currentItem = items[i];

                string storekeeperName = "неизвестен";
                if (storekeepers != null)
                {
                    for (int j = 0; j < storekeepers.Count; j++)
                    {
                        if (storekeepers[j].Id == currentItem.StorekeeperId)
                        {
                            storekeeperName = storekeepers[j].FullName;
                            break;
                        }
                    }
                }

                string sectionName = "неизвестен";
                if (sections != null)
                {
                    for (int j = 0; j < sections.Count; j++)
                    {
                        if (sections[j].Id == currentItem.SectionId)
                        {
                            sectionName = sections[j].Name;
                            break;
                        }
                    }
                }

                Console.WriteLine(currentItem.GetInfo() + " - кладовщик " + storekeeperName + ", секция " + sectionName);
            }
        }

    }
}
