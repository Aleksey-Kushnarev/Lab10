using LabLibrary;

namespace Demonstration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Carriage[] arr = new Carriage[20];
            CreateArray(ref arr);
            ConsoleKey key;
            do
            {
                Console.WriteLine("========================");
                Console.WriteLine("1 - Вывести массив");
                Console.WriteLine("2 - Отсоритровать по имени и найти элемент");
                Console.WriteLine("3 - Отсортировать по скорости и найти элемент");
                Console.WriteLine("4 - Процент посетителей в вагоне ресторне");
                Console.WriteLine("5 - Минимальная из максимальных скорость вагонов");
                Console.WriteLine("6 - Получить общий тоннаж");
                Console.WriteLine("Esc - Выход");
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case (ConsoleKey.D1):
                        foreach (var item in arr)
                        {
                            item.Show();
                        }
                        break;

                    case (ConsoleKey.D2):
                        Array.Sort(arr);
                        Console.WriteLine("Введите имя, которое нужно найти");
                        string name = Console.ReadLine();
                        Console.WriteLine("Индекс элемента:");
                        Console.WriteLine(Array.BinarySearch(arr, new Carriage(0, name, 1)));
                        break;

                    case (ConsoleKey.D3):
                        Array.Sort(arr, new SortBySpeed());
                        Console.WriteLine("Введите скорость, которую нужно найти");
                        try
                        {
                            int speed = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Индекс элемента:");
                            Console.WriteLine(Array.BinarySearch(arr, new Carriage(0, "name", speed),
                                new SortBySpeed()));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        
                        break;
                    case (ConsoleKey.D4):
                        Console.WriteLine(GetPercentPassengersInRestaurant(arr));
                        break;
                    case (ConsoleKey.D5):
                        Console.WriteLine(GetMinSpeed(arr));
                        break;
                    case (ConsoleKey.D6):
                        Console.WriteLine(GetTotalWeight(arr));
                        break;
                    case (ConsoleKey.Escape):
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;

                }
                
            } while (key != ConsoleKey.Escape);



            Console.WriteLine("============Остальные примеры============");
            Coach example = new Coach(2, "asda", 33, 21, 22);
            Coach exCopy = (Coach)example.ShallowCopy();
            example.Id.Id = 12;
            Console.WriteLine(example);
            Restaurant a = new Restaurant();
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(exCopy);
            Console.WriteLine("=======");
            example = new Coach(2, "asda", 33, 21, 22);
            exCopy = (Coach)example.Clone();
            example.Id.Id = 12;
            Console.WriteLine(example);

            Console.WriteLine(exCopy);
            Console.WriteLine("=======");
            Discipline d = new Discipline();
            d.RandomInit();

            IInit[] arr2 = new IInit[] { (IInit)example, (IInit)d};

            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
            
        }

        public static double GetPercentPassengersInRestaurant(Carriage[] arr)
        {
            double totalPassengers = 0;
            double restaurantsSeats = .0;
            foreach (var item in arr)
            {
                if (item is Restaurant r)
                {
                    restaurantsSeats += r.Seats;
                }
                else if (item is Coach c)
                {
                    totalPassengers += c.Beds + c.Seats;
                }
            }
            return restaurantsSeats / totalPassengers * 100;
            
        }


        public static void CreateArray(ref Carriage[] arr)
        {
            for (int i = 0; i < 5; i++)
            {
                Carriage c = new Carriage();
                c.RandomInit();
                arr[i] = c;
            }

            for (int i = 5; i < 10; i++)
            {
                Freight c = new Freight();
                c.RandomInit();
                arr[i] = c;

            }
            for (int i = 10; i < 15; i++)
            {
                Coach c = new Coach();
                c.RandomInit();
                arr[i] = c;
            }

            for (int i = 15; i < 20; i++)
            {
                Restaurant c = new Restaurant();
                c.RandomInit();
                arr[i] = c;
            }
        }
        public static int GetTotalWeight(Carriage[] arr)
        {
            int totalWeight = 0;
            foreach (var item in arr)
            {
                if (item is Freight r)
                {
                    totalWeight += r.Weight;
                }
                
            }
            return totalWeight;

        }

        public static int GetMinSpeed(Carriage[] arr)
        {
            int minSpeed = Carriage.GetMaxSpeed;
            foreach (var item in arr)
            {
                if (minSpeed < item.MaxSpeed)
                {
                    minSpeed = item.MaxSpeed;
                }

            }
            return minSpeed;

        }

    }

}
