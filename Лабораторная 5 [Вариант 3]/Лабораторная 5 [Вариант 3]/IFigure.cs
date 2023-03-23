using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication
{
    interface IFigure
    {
        double area
        {
            get;
        }
        double length();
        void vyvod(int k, int n);
        int this[int i]
        {
            get;
        }
    }
}