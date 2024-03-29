﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace LabLibrary
{
    public class Coach : Carriage, ICloneable, IEquatable<Coach>
    {
        public static int GetMaxSeats => 80;
        public static int GetMaxBeds => 60;

        private int _seats;
        public int Seats
        {
            get => _seats;
            set
            {
                if (0 > value || GetMaxSeats < value)
                    throw new ArgumentOutOfRangeException($"{value}", $"Значение должно быть в пределах от 0 до {GetMaxSeats}");
                _seats = value;
            }
        }

        private int _beds;
        public int Beds
        {
            get => _beds;
            set
            {
                if (0 > value || GetMaxBeds < value)
                    throw new ArgumentOutOfRangeException("{value}",$"Значение должно быть в пределах от 0 до {GetMaxSeats}");
                _beds = value;
            }
        }
        public Coach(int id, string number, int maxSpeed, int seats, int beds) : base(id, number, maxSpeed)
        {
            Seats = seats;
            Beds = beds;
        }

        public Coach() : base()
        {
            Seats = 0;
            Beds = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $", Seats = {Seats}, Beds = {Beds}";
        }


        public override bool Equals(Object obj) => Equals(obj as Coach);
        

        public bool Equals(Coach? other)
        {
            if(other == null) return false;
            return base.Equals(other) && Seats == other.Seats &&  Beds == other.Beds;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 23 +(Seats.GetHashCode() * Beds.GetHashCode());
        }

        
        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите количество мест");
            try
            {
                Seats = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message + "\nУстановлено значение по умолчанию");
                Seats = 0;
            }
            Console.WriteLine("введите количество койко-месь");
            try
            {
                Beds = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message + "\nУстановлено значение по умолчанию");
                Beds = 0;
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Beds = Rnd.Next(GetMaxBeds);
            Seats = Rnd.Next(GetMaxSeats);
        }
        public new object Clone()
        {
            return new Coach(Id.Id, Name, MaxSpeed, Seats, Beds);
        }

        

    }
}
