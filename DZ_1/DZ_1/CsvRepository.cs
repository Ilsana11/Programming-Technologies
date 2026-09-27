using static System.Collections.Specialized.BitVector32;

namespace DZ_1
{
    /// <summary>
    /// Репозиторий для данных из CSV-файлов
    /// </summary>
    public class CsvRepository
    {
        private string _basePath;
        public CsvRepository(string basePath) 
        { 
            _basePath = basePath; 
        }

        public List<Section> GetSections()
        {
            List<Section> result = new List<Section>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "sections.csv"));
            if (lines.Length < 2)
            {
                return result;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;
                Section s = new Section();
                s.Id = int.Parse(parts[0]);
                s.Name= parts[1];
                s.Area = int.Parse(parts[2]);
                result.Add(s);
            }
            return result;
        }

        public List<Storekeeper> GetStorekeepers()
        {
            List<Storekeeper> result = new List<Storekeeper>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "storekeeper.csv"));
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 4) continue;

                Storekeeper s = new Storekeeper();
                s.Id = int.Parse(parts[0]);
                s.FullName = parts[1];
                s.Shift = parts[2];
                s.Experience = int.Parse(parts[3]);
                result.Add(s);
            }
            return result;

        }

        public List<Item> GetItems()
        {

            List<Item> result = new List<Item>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "item.csv"));
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;
                int id = int.Parse(parts[0]);
                string name = parts[1];
                int sectionId = int.Parse(parts[2]);
                int storekeeperId = int.Parse(parts[3]);
                int quantity = int.Parse(parts[4]);
                decimal price = decimal.Parse(parts[5]);

                Item e = new Item(id, name, sectionId, storekeeperId, quantity, price);
                result.Add(e);
                
            }
            return result;
        }
    }
}
