using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLibrary
{
    public class SortBySpeed : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Carriage c = x as Carriage;
            Carriage c2 = y as Carriage; 
            if(c.MaxSpeed > c2.MaxSpeed) return 1;
            else if (c.MaxSpeed == c2.MaxSpeed) return 0;
            else return -1;

        }
    }
}
