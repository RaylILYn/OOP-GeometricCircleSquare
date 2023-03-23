using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int i = 0;
            Circle[] C = new Circle[10];
            Square[] Q = new Square[10];
            Table t = new Table();
            StringBuilder[] circles = new StringBuilder[10];
            StringBuilder[] squares = new StringBuilder[10];
            for (int k = 0; k < 10; k++)
            {
                circles[k] = new StringBuilder();
                squares[k] = new StringBuilder();
            }
            try
            {
                StreamReader f = new StreamReader("input.txt");
                s = f.ReadToEnd();
                f.Close();
                Console.WriteLine("Строка\n\n" + s);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            // Поиск кругов
            Console.WriteLine("\nПоиск кругов");
            Regex FindCircle = new Regex(@"[-]*\d+\s[-]*\d+\s[-]*\d+\s[A-Z]([a-z])+");
            Match m = FindCircle.Match(s);
            while (m.Success)
            { 
                circles[i].Insert(0, m.Value);
                m = m.NextMatch();
                i += 1;
            }
            i = 0;

            // Поиск квадратов
            Regex FindSquares = new Regex(@"[A-Z]([a-z])+\s[-]*\d+\s[-]*\d+\s[-]*\d+\s[-]*\d+\s[-]*\d+\s[-]*\d+\s[-]*\d+\s[-]*\d+");
            Match h = FindSquares.Match(s);
            while (h.Success)
            {
                squares[i].Insert(0, h.Value);
                h = h.NextMatch();
                i += 1;
            }

            // Добавление в классы кругов
            for (int k = 0; k < circles.Length; k++)
            {
                string bread = Convert.ToString(circles[k]);
                char[] sps = { ' ' };
                string[] parts = bread.Split(sps);
                {
                    if (parts.Length > 1)
                    {
                        C[k] = new Circle(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]), parts[3]);
                        C[k].vyvod(1, 1);
                    }
                }
            }

            // Добавление в классы квадратов
            Console.WriteLine("\nПоиск квадратов");
            for (int k = 0; k < squares.Length; k++)
            {
                string bread = Convert.ToString(squares[k]);
                char[] sps = { ' ' };
                string[] parts = bread.Split(sps);
                {
                    if (parts.Length > 1)
                    {
                        Q[k] = new Square(parts[0], Int32.Parse(parts[1]), Int32.Parse(parts[2]), Int32.Parse(parts[3]), Int32.Parse(parts[4]),
                       Int32.Parse(parts[5]), Int32.Parse(parts[6]), Int32.Parse(parts[7]), Int32.Parse(parts[8]));
                        Q[k].vyvod(1, 1);
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();

            bool exit = false; int punkt;
            while (!exit)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1: Добавить квадрат");
                Console.WriteLine("2: Добавить круг");
                Console.WriteLine("3: Вывод данных");
                Console.WriteLine("4: Сортировка площадей квадратов по возрастанию"); 
                Console.WriteLine("5: Поиск периметра квадратов находящихся в более чем 1 плоскости"); 
                Console.WriteLine("6: Вывод длин всех окружностей");
                Console.WriteLine("0: Выxод");
                punkt = Int32.Parse(Console.ReadLine());
                switch (punkt)
                {
                        // Добавить квадрат
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("1");
                            int k = 0;
                            while (Q[k] != null) k += 1;
                            if (k < 10)
                            {
                                int[] v = new int[8];
                                Console.WriteLine("Введите цвет " + k);
                                string col = Console.ReadLine();
                                Console.WriteLine("Введите координаты правой верхней вершины и длину ребра(x1, y1, a)"); 
                                v[0] = Int32.Parse(Console.ReadLine());
                                v[1] = Int32.Parse(Console.ReadLine());
                                int a = Int32.Parse(Console.ReadLine());
                                v[2] = v[0] - a;
                                v[3] = v[1];
                                v[4] = v[0] - a;
                                v[5] = v[1] - a;
                                v[6] = v[0];
                                v[7] = v[1] - a;
                                Q[k] = new Square(col, v[0], v[1], v[2], v[3], v[4], v[5], v[6], v[7]);
                                Console.WriteLine("Квадрат создан");
                            }
                            else Console.WriteLine("Таблица переполнена");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                        // Добавить круг
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("2");
                            int k = 0;
                            while (C[k] != null) k += 1;
                            if (k < 10)
                            {
                                Console.WriteLine("Введите цвет окружности " + k);
                                string col = Console.ReadLine();
                                Console.WriteLine("Введите координаты центра окружности и радиус(x, y, R) "); 
                                
                                int x = Int32.Parse(Console.ReadLine());
                                int y = Int32.Parse(Console.ReadLine());
                                int r = Int32.Parse(Console.ReadLine());
                                C[k] = new Circle(x, y, r, col);
                                Console.WriteLine("Круг создан");
                            }
                            else Console.WriteLine("Таблица переполнена");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                        // Вывод данных
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("3");
                            t.TableHead();
                            int k = 0;
                            while (C[k] != null)
                            {
                                C[k].vyvod(2, k);
                                k = k + 1;
                            }
                            k = 0;
                            while (Q[k] != null)
                            {
                                Q[k].vyvod(2, k);
                                k = k + 1;
                            }
                            t.TableDown();
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                        // Сортировка площадей по возрастанию
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("4");
                            int k = 0;
                            while (Q[k] != null)
                                k = k + 1;
                            for (int p = 0; p < k; p++)
                            {
                                Square[] tmp = new Square[k];
                                for (i = 0; i < k; i++)
                                {
                                    tmp[i] = Q[i];
                                }
                                Array.Sort(tmp, new SortArea());
                                i = 0;
                                while (i < k)
                                {
                                    Q[i] = tmp[i];
                                    i = i + 1;
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                        // Поиск периметра квадратов находящихся в более чем 1 плоскости
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("5");
                            int k = 0;
                            bool flag1 = false;
                            bool flag2 = false;
                            while (Q[k] != null)
                            {
                                // Квадрат в 1 4 или 2 3 
                                if ((Q[k].x[0] > 0 && Q[k].x[1] > 0 &&
                               Q[k].x[2] > 0 && Q[k].x[3] > 0) || (Q[k].x[0] < 0 && Q[k].x[1] < 0 &&
                               Q[k].x[2] < 0 && Q[k].x[3] < 0))             
                                    flag1 = true;

                                // Квадрат в 1 2 или 3 4 
                                if ((Q[k].y[0] > 0 && Q[k].y[1] > 0 &&
                               Q[k].y[2] > 0 && Q[k].y[3] > 0) || (Q[k].y[0] < 0 && Q[k].y[1] < 0 &&
                               Q[k].y[2] < 0 && Q[k].y[3] < 0))             
                                    flag2 = true;

                                if (flag1 == true && flag2 == true)
                                    Console.WriteLine("Квадрат - " + k + " Периметр = " + Q[k].length() + "\tВ 1 плоскоти");
                                else
                                {
                                    Console.WriteLine("Квадрат - " + k + " Периметр = " + Q[k].length());
                                }
                                flag1 = false; flag2 = false;
                                k = k + 1;
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                        // Вывод длин всех окружностей
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("6");
                            int k = 0;
                            while (C[k] != null)
                                k = k + 1;
                            double[] tmp = new double[k];
                            k = 0;
                            while (C[k] != null)
                            {
                                tmp[k] = C[k].length();
                                k = k + 1;
                            }
                            Array.Sort(tmp);
                            for (i = 0; i < tmp.Length; i++)
                            {
                                Console.WriteLine("Окружность - " + i + " Длина = " + Convert.ToInt32(tmp[i]));
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                        // Выxод
                    case 0:
                        {
                            exit = true;
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
        }
    }
}