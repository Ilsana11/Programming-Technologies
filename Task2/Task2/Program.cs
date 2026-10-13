namespace Task2;

internal class Program
{
    static void Main(string[] args)
    {
        List<Dish> menu = new List<Dish>
        {
            new Soup(1, "Borsht", 350m, true),
            new Steak(2, "Ribye", 1500m, "medium"),
            new Cake(3, "Napaleon", 450m, 4)
        };

        foreach (Dish dish in menu)
        {
            Console.WriteLine(dish);
            Console.WriteLine($"  price with service: {dish.PriceWithService}");
            dish.Cook();

            if (dish is IServable servable)
            {
                servable.Serve();
            }
            else
            {
                Console.WriteLine($"{dish.Name} cannot be served");
            }
            Console.WriteLine(new string ('-', 40));
        }

    }
}