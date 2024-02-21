using LabLibrary;

namespace Demonstration
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Carriage[] arr = new Carriage[20];
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
            

            Coach example = new Coach(2, "asda", 33, 21, 22);
            Coach exCopy = (Coach)example.ShallowCopy();
            example.Id.Id = 12;
            Console.WriteLine(example);
            
            Console.WriteLine(exCopy);
            Console.WriteLine("=======");
            arr[4] = example;
            Array.Sort(arr, new SortBySpeed());
            foreach (var elem in arr)
            {
                elem.Show();
            }

            Discipline d = new Discipline();
            d.RandomInit();
            Console.WriteLine(Array.BinarySearch(arr, new Carriage(2, "aa", 33), new SortBySpeed()));

            IInit[] arr2 = new IInit[] { (IInit)example, (IInit)d};

            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
            Carriage[] actual = new[] { new Carriage(1, "A", 20), new Carriage(0, "C", 30), new Carriage(2, "B", 10) };
            Array.Sort(actual, new SortBySpeed());

            foreach (var item in actual)
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
