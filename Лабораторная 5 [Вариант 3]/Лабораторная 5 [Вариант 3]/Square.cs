using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication
{
    class Square : IFigure
    {
        public int[] x = new int[4];
        public int[] y = new int[4];
        public string color;
        public Square(string color, int x1, int y1, int x2, int y2, int x3,
       int y3, int x4, int y4)
        {
            x[0] = x1; x[1] = x2; x[2] = x3; x[3] = x4;
            y[0] = y1; y[1] = y2; y[2] = y3; y[3] = y4;
            this.color = color;
        }
        public double area
        {
            get
            {
                return ((x[0] - x[1]) * (x[0] - x[1]));
            }
        }
        public double length()
        {
            return (Math.Abs(x[0] - x[1]) * 4);
        }
        public void vyvod(int k, int n)
        {
            switch (k)
            {
                case 1:
                    Console.Write("|{0, 10}|", color);
                    for (int i = 0; i < x.Length; ++i)
                        Console.Write(" " + x[i] + " " + y[i]);
                    Console.WriteLine("|");
                    break;
                case 2:
                    Square AA = new Square(color, x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                    Table t = new Table();
                    t.TableSquare(AA, n);
                    break;
            }
        }
        public int this[int i]
        {
            get
            {
                return x[i];
            }
        }
    }
}