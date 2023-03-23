using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ConsoleApplication
{
    class SortArea : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            Square so1 = (Square)obj1;
            Square so2 = (Square)obj2;
            if (so1.area > so2.area) return 1;
            if (so1.area < so2.area) return -1;
            else return 0;
        }
    }
}