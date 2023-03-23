using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication
{
    class Circle : IFigure
    {
        int x, y;
        public string color;
        int R;
        public Circle(int x, int y, int R, string color)
        {
            this.x = x; this.y = y; this.R = R; this.color = color;
        }
        public double area
        {
            get
            {
                return (Math.PI * R * R);
            }
        }
        public double length()
        {
            return (2 * Math.PI * R);
        }
        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 1:
                        return x;
                    case 2:
                        return y;
                }
                return x;
            }
        }
        public void vyvod(int k, int n)
        {
            switch (k)
            {
                case 1:
                    Console.WriteLine("|{0, 10}| " + x + " " + y + " " + R + " |", color);
                    break;
                case 2:
                    Circle AA = new Circle(x, y, R, color);
                    Table t = new Table();
                    t.TableCircle(AA, n);
                    break;
            }
        }
    }
}