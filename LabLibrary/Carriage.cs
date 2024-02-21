using Exception = System.Exception;

namespace LabLibrary
{
    public class IdNumber
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException($"{value}", "Id должен быть неотрицательным числом");
                _id = value;
            }
        }

        public IdNumber(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id = {Id}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is IdNumber t)
            {
                return t.Id == Id;
            }
            return false;
        }
    }


    public class Carriage: IInit, IComparable<Carriage>, ICloneable
    {

        public static int GetMaxSpeed => 150;

        protected Random Rnd = new Random();

        static readonly string[] Letters = { "AB", "TR", "PO", "JH", "UG", "LE" };
        static readonly string[] Indexes = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        public string Name { get; set; }

        private int _maxSpeed;
        public IdNumber Id;

        public int MaxSpeed
        {
            get => _maxSpeed;
            set
            {
                if (value <= 0 || value > GetMaxSpeed)
                    throw new ArgumentOutOfRangeException($"{value}", "Скорость должна быть больше 0");
                _maxSpeed = value;
            }
        }

        public Carriage()
        {
            Name = "default";
            MaxSpeed = 100;
            Id = new IdNumber(1);
        }

        public Carriage(int id, string number, int maxSpeed)
        {
            Name = number;
            MaxSpeed = maxSpeed;
            Id = new IdNumber(id);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Carriage p)
                return this.Name == p.Name && this.MaxSpeed == p.MaxSpeed;
            return false;
        }

        public override string ToString()
        {
            return Id + $" Name = {Name}, Speed = {MaxSpeed}";
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
            Id = new IdNumber(Rnd.Next(100));
            Name = Letters[Rnd.Next(Letters.Length)] + Indexes[Rnd.Next(Indexes.Length)] +
                     Indexes[Rnd.Next(Indexes.Length)] + Indexes[Rnd.Next(Indexes.Length)] + Indexes[Rnd.Next(Indexes.Length)];
            MaxSpeed = Rnd.Next(30, GetMaxSpeed);
        }
        public int CompareTo(Carriage? carriage)
        {
            if (carriage is null) throw new ArgumentException("Некорректное значение параметра");
            return String.Compare(Name, carriage.Name, StringComparison.Ordinal);
        }

        public object Clone()
        {
            return new Carriage(Id.Id, Name, MaxSpeed);
        }

        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}
