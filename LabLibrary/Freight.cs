using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLibrary
{
    public class Freight : Carriage, ICloneable, IEquatable<Freight>
    {
        private static string[] _typesOfCargo = { "Salt", "Oil", "Coal", "Gas", "Animals"};
        public string TypeOfCargo { get; set; }
        public int GetMaxWeight => 100;

        private int _weight;

        public int Weight
        {
            get => _weight;
            set
            {
                if (value < 0 || value > GetMaxWeight) throw new ArgumentOutOfRangeException($"{value}",
                    $"Значение веса должно быть в пределах от 0 до {GetMaxWeight}");
                _weight = value;
            }
        }

        public Carriage BaseCarriage()
        {
            return new Carriage(Id.Id, Name, MaxSpeed);
        }
        public Freight() : base()
        {
            TypeOfCargo = "default";
            Weight = 10;
        }

        public Freight(int id, string name, int speed, string typeOfCargo, int weight) : base(id, name, speed)
        {
            TypeOfCargo = typeOfCargo;
            Weight = weight;
        }

        public override string ToString()
        {
            return base.ToString() + $", Type of cargo = {TypeOfCargo}, Weight = {Weight}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите тип грузза");
            TypeOfCargo = Console.ReadLine();
            Console.WriteLine("Введите тоннаж");
            try
            {
                Weight = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                Weight = 10;
            }

        }

        public override void RandomInit()
        {
            base.RandomInit();
            Weight = Rnd.Next(GetMaxWeight);
            TypeOfCargo = _typesOfCargo[Rnd.Next(_typesOfCargo.Length)];
        }

        
        public override bool Equals(Object obj) => Equals(obj as Freight);

        public bool Equals(Freight? other)
        {
            if (other == null) return false;
            return base.Equals(other) && Weight == other.Weight && TypeOfCargo == other.TypeOfCargo;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 23 + (Weight.GetHashCode() * TypeOfCargo.GetHashCode());
        }

        public new object Clone()
        {
            return new Freight(Id.Id, Name, MaxSpeed, TypeOfCargo, Weight);
        }
    }
}
