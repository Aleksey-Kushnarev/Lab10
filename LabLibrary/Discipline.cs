
namespace LabLibrary
{
    public class Discipline: IInit
    {
        private static readonly string[] Names = { "Русский", "Математика", "Правовая грамотность", "Программирование"};
        protected Random Rnd = new Random();
        public string Name
        {
            get;
            set;
        }

        private int _contactHours;
        private int _selfHours;
        public int ContactHours
        {
            get => _contactHours;
            set
            {
                if (value < 0) throw new Exception("Значение должно быть больше 0");
                _contactHours = value;
            }
        }

        public int SelfHours
        {
            get => _selfHours;
            set
            {
                if (value < 0) throw new Exception("Значение должно быть больше 0");
                _selfHours = value;
            }

        }

        public int CreditUnit
        {
            get => (SelfHours + ContactHours) / 38;
        }

        public int SumHours
        {
            get => SelfHours + ContactHours;
        }

        public Discipline(Discipline discipline)
        {
            Name = discipline.Name;
            ContactHours = discipline.ContactHours;
            SelfHours = discipline.SelfHours;
        }


        public Discipline(string name, int contactHours, int selfHours)
        {
            Name = name;
            ContactHours = contactHours <= 0 ? 0 : contactHours;
            SelfHours = selfHours <= 0 ? 0 : selfHours;
        }
        public Discipline(string name)
        {
            Name = name;
            ContactHours = 0;
            SelfHours = 0;
        }

        public Discipline()
        {
            Name = "default";
            ContactHours = 0;
            SelfHours = 0;
        }

        /// <summary>
        /// определение процентного соотношения самостоятельной работы к общему количеству часов, выделенных на дисциплину, результат – вещественное число от 0 до 100 
        /// </summary>
        /// <param name="discipline"></param>
        /// <returns></returns>

        public static double operator !(Discipline discipline)
        {
            double res = (discipline.SelfHours) / 1.0 / discipline.SumHours * 100;
            return res;
        }

        // Операции увеличения часов

        public static Discipline operator +(Discipline discipline, int hours)
        {
            if (discipline.SelfHours - hours < 0)
            {
                throw new Exception("ERROR! SelfHours must be greater than 0");
            }

            discipline.ContactHours += hours;
            discipline.SelfHours -= hours;
            return discipline;
        }

        public static Discipline operator ++(Discipline discipline)
        {
            if (discipline.SelfHours - 2 < 0)
            {
                throw new Exception("ERROR! SelfHours must be greater than 0");
            }
            discipline.ContactHours += 2;
            discipline.SelfHours -= 2;
            return discipline;
        }

        // Операции преобразования
        /// <summary>
        /// Доля аудиторных часов от всех часов
        /// </summary>
        /// <param name="discipline"></param>
        public static explicit operator double(Discipline discipline)
        {
            return (discipline.ContactHours) / 1.0 / discipline.SumHours;
        }

        /// <summary>
        /// Количество аудиторных занятий
        /// </summary>
        /// <param name="discipline"></param>
        public static implicit operator int(Discipline discipline)
        {
            return (discipline.ContactHours) / 2;
        }

        // Операции сравнения

        public static bool operator <(Discipline discipline1, Discipline discipline2)
        {
            bool res = discipline1.SumHours < discipline2.SumHours;
            return res;
        }
        public static bool operator >(Discipline discipline1, Discipline discipline2)
        {
            bool res = discipline1.SumHours > discipline2.SumHours;
            return res;
        }
        public static bool operator <=(Discipline discipline1, Discipline discipline2)
        {
            bool res = discipline1.SumHours <= discipline2.SumHours;
            return res;
        }
        public static bool operator >=(Discipline discipline1, Discipline discipline2)
        {
            bool res = discipline1.SumHours >= discipline2.SumHours;
            return res;
        }
        public static bool operator ==(Discipline discipline1, Discipline discipline2)
        {
            bool res = discipline1.SumHours == discipline2.SumHours;
            return res;
        }

        public static bool operator !=(Discipline discipline1, Discipline discipline2)
        {
            bool res = discipline1.SumHours != discipline2.SumHours;
            return res;
        }

        public override string ToString()
        {
            return $"Discipline {this.Name} has {this.ContactHours} Contact hours and {this.SelfHours} Self hours.";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Discipline s)
            {
                return s.Name == Name && s.SumHours == SumHours;
            }

            return false;
        }

        public void Init()
        {
            Console.WriteLine("Введите название дисциплины");
            Name = Console.ReadLine();
            Console.WriteLine("Введите число аудиторных часов");
            try
            {
                ContactHours = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Введите число внеаудиторных часов");
            try
            {
                SelfHours = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void RandomInit()
        {
            Name = Names[Rnd.Next(Names.Length)];
            ContactHours = Rnd.Next(5, 100);
            SelfHours = Rnd.Next(5, 100);
        }
    }
}

