using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLibrary
{
    public class Restaurant : Coach, ICloneable, IEquatable<Restaurant>
    {
        static string[] _workTimes = { "08:00 - 21:00", "18:00 - 23:30", "10:00 - 22:00", "11:00 - 18:00"};
        public string WorkTime { get; set; }

        public Restaurant(int id, string name, int speed, int seats, string workTime) : base(id, name, speed, seats, 0) 
        {
            WorkTime = workTime;
        }
        public Restaurant() : base()
        {
            WorkTime = "default";
        }

        public override bool Equals(Object obj) => Equals(obj as Restaurant);
        
        public bool Equals(Restaurant? other)
        {
            if (other == null) return false;
            return base.Equals(other) && WorkTime == other.WorkTime;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 23 + (WorkTime.GetHashCode());
        }

        public override void Init()
        {
            base.Init();
            if (Beds > 0)
            {
                Console.WriteLine("Койко-мест в вагоне ресторане не может быть!");
                Beds = 0;
            }
            Console.WriteLine("Введите график работы");
            WorkTime = Console.ReadLine();

        }

        public override void RandomInit()
        {
            base.RandomInit();
            WorkTime = _workTimes[Rnd.Next(_workTimes.Length)];
            Beds = 0;
        }

        public override string ToString()
        {
            return base.ToString() + ", Work Time = " + WorkTime;
        }
        public new object Clone()
        {
            return new Restaurant(Id.Id, Name, MaxSpeed, Seats, WorkTime);
        }
    }
}
