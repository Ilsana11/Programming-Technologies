using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace DZ_1
{
    /// <summary>
    /// Репозиторий с данными в памяти
    /// </summary>
    public class InMemoryRepository
    {
        private List<Section> _section;
        private List<Storekeeper> _storekeeper;
        private List<Item> _item;

        public InMemoryRepository()
        {
            _section = new List<Section>
            {
                new Section {Id = 1, Name = "Метизы", Area = 300 },
                new Section {Id = 2, Name = "Электрика", Area = 150 },
                new Section {Id = 3, Name = "Стройматериалы", Area = 500 }
            };

            _storekeeper = new List<Storekeeper>
            {
                new Storekeeper {Id = 1, FullName = "Петров П.П.", Shift = "Утренняя", Experience = 5},
                new Storekeeper {Id = 2 , FullName = "Иванов И.И.", Shift = "Ночная", Experience = 2},
                new Storekeeper {Id = 3, FullName = "Сидоров С.С", Shift = "Утренняя", Experience = 8}
            };

            _item = new List<Item>
            {
                new Item(1, "Болты М8",1 ,1, 1000, 5 ),
                new Item(  2, "Гайки", 1 ,  1,  50, 3 ),
                new Item ( 3, "Шайбы", 1 ,  3,  80,  1 ),
                new Item (  4, "Провод", 2 ,  2, 200,  50 ),
                new Item ( 5,  "Цемент", 3 ,  3, 500,  400 ),
            };
        }
        public List<Section> GetSections() { return _section; }
        public List<Storekeeper> GetStorekeepers() { return _storekeeper; }
        public List<Item> GetItems() { return _item; }
       
    }
}
