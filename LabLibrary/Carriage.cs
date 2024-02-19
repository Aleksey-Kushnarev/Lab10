using System.Xml.Linq;
using System;
using Exception = System.Exception;

namespace LabLibrary
{
    public class Carriage//, IComparable<Person>, ICloneable, IEquatable<Person>
    {
        public static int GetMaxSpeed => 150;

        private Random rnd = new Random();

        static string[] Letters = { "AB", "TR", "PO", "JH", "UG", "LE" };
        static string[] Indexes = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        public string Name { get; set; }

        private int _maxSpeed;

        public int MaxSpeed
        {
            get => _maxSpeed;
            set
            {
                if (value <= 0 || value > GetMaxSpeed)
                    throw new Exception("Скорость должна быть больше 0");
                _maxSpeed = value;
            }
        }

        public Carriage()
        {
            Name = "default";
            MaxSpeed = 100;
        }

        public Carriage(string number, int maxSpeed)
        {
            Name = number;
            MaxSpeed = maxSpeed;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Carriage p)
                return this.Name == p.Name && this.MaxSpeed == p.MaxSpeed;
            return false;
        }

        public override string ToString()
        {
            return $"Name = {Name}, Speed = {MaxSpeed}";
        }

        public void Show()
        {
            Console.WriteLine(ToString());
        }

        public virtual void Init()
        {
            Console.WriteLine("введите номер вагона");
            Name = Console.ReadLine();
            Console.WriteLine("введите максимальную скорость");
            try
            {
                MaxSpeed = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                MaxSpeed = 100;
            }
        }

        public virtual void RandomInit()
        {
            Name = Letters[rnd.Next(Letters.Length)] + Indexes[rnd.Next(Indexes.Length)] +
                     Indexes[rnd.Next(Indexes.Length)] + Indexes[rnd.Next(Indexes.Length)] + Indexes[rnd.Next(Indexes.Length)];
            MaxSpeed = rnd.Next(30, 180);
        }
    }
    }
