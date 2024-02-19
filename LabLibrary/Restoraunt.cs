using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLibrary
{
    public class Restoraunt : Coach
    {
        public string WorkTime { get; set; }

        public Restoraunt(string name, int speed, int seats, string workTime) : base(name, speed, seats, 0) 
        {
            WorkTime = workTime;
        }
        public Restoraunt() : base()
        {
            WorkTime = "default";
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

        public override string ToString()
        {
            return base.ToString() + " Work Time = " + WorkTime;
        }
    }
}
