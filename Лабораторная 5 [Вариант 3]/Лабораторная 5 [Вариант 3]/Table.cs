using ConsoleApplication;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
namespace ConsoleApplication
{
    class Table
    {
        int x1, x2, x3, x4;
        public Table()
        {
            x1 = 10; x2 = 10; x3 = 10; x4 = 15;
        }
        public void TableHead()
        {
            int i;
            Console.Write("╔");
            for (i = 0; i < x1; i++) Console.Write("=");
            Console.Write("╦");
            for (i = 0; i < x2; i++) Console.Write("=");
            Console.Write("╦");
            for (i = 0; i < x3; i++) Console.Write("=");
            Console.Write("╦");
            for (i = 0; i < x4; i++) Console.Write("=");
            Console.WriteLine("╗");
            string s = "║{0,-" + x1.ToString() + "}║{1,-" + x2.ToString() + "}║{2,-" + x3.ToString() + "}║{3,-" + x4.ToString() + "}║";
            Console.WriteLine(s, "Номер", "Вид фигуры", "Площадь", "Периметр(длина)");
            Console.Write("╠");
            for (i = 0; i < x1; i++) Console.Write("=");
            Console.Write("╬");
            for (i = 0; i < x2; i++) Console.Write("=");
            Console.Write("╬");
            for (i = 0; i < x3; i++) Console.Write("=");
            Console.Write("╬");
            for (i = 0; i < x4; i++) Console.Write("=");
            Console.WriteLine("╣");
        }
        public void TableDown()
        {
            Console.Write("╚");
            for (int i = 0; i < x1; i++) Console.Write("=");
            Console.Write("╩");
            for (int i = 0; i < x2; i++) Console.Write("=");
            Console.Write("╩");
            for (int i = 0; i < x3; i++) Console.Write("=");
            Console.Write("╩");
            for (int i = 0; i < x4; i++) Console.Write("=");
            Console.Write("╝");
        }
        public void TableCircle(Circle a, int k)
        {
            string s = "║{0,-" + x1.ToString() + "}║{1,-" + x2.ToString() + "}║{2,-" + x3 + ":f3}║{3,-" + x4 + ":f3}║";
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), a.color);
            Console.ForegroundColor = color;
            Console.WriteLine(s, k, "Круг", a.area, a.length());
            Console.ResetColor();
        }
        public void TableSquare(Square a, int k)
        {
            string s = "║{0,-" + x1.ToString() + "}║{1,-" + x2.ToString() +
           "}║{2,-" + x3 + ":f3}║{3,-" + x4 + ":f3}║";
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), a.color);
            Console.ForegroundColor = color;
            Console.WriteLine(s, k, "Квадрат", a.area, a.length());
            Console.ResetColor();
        }
    }
}

