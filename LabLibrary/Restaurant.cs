using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLibrary
{
    public class Restaurant : Coach, ICloneable
    {
        static string[] WorkTimes = { "08:00 - 21:00", "18:00 - 23:30", "10:00 - 22:00", "11:00 - 18:00"};
        public string WorkTime { get; set; }

        public Restaurant(int id, string name, int speed, int seats, string workTime) : base(id, name, speed, seats, 0) 
        {
            WorkTime = workTime;
        }
        public Restaurant() : base()
        {
            WorkTime = "default";
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (obj is Restaurant p)
                return base.Equals(obj) && WorkTime == p.WorkTime;
            return false;
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
            WorkTime = WorkTimes[rnd.Next(WorkTimes.Length)];
            Beds = 0;
        }

        public override string ToString()
        {
            return base.ToString() + " Work Time = " + WorkTime;
        }
        public new object Clone()
        {
            return new Restaurant(id.Id, Name, MaxSpeed, Seats, WorkTime);
        }
    }
}
