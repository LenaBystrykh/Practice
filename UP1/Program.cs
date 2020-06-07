using System;

namespace UP1
{
    // Задача 1. https://acmp.ru/index.asp?main=task&id_task=102
    // В декартовой системе координат на плоскости заданы координаты вершин треугольника и еще одной точки. 
    // Требуется написать программу, определяющую, принадлежит ли эта точка треугольнику.
    class Program
    {
        static void Main(string[] args)
        {
            // Координаты трёх точек треугольника и тестируемой точки
            int firstPointX, firstPointY, secondPointX, secondPointY, thirdPointX, thirdPointY, pointX, pointY;

            // Переменная нахождения точки внутри заданного треугольника, true - внутри, false - снаружи
            bool inside = false;

            // Проверка правильности ввода точек
            inside = GetPoints(out firstPointX, out firstPointY, out secondPointX, out secondPointY,
            out thirdPointX, out thirdPointY, out pointX, out pointY, inside);

            // Если точки введены верно, проверка существования треугольника
            if (inside == true)
            {
                inside = false;
                inside = CheckTriangle(firstPointX, firstPointY, secondPointX, secondPointY, thirdPointX, thirdPointY, pointX, pointY, inside);

                // Если треугольник существует, проверка принадлежности точки заданной области
                if (inside == true)
                {
                    inside = false;
                    inside = CheckPoint(firstPointX, firstPointY, secondPointX, secondPointY, thirdPointX, thirdPointY, pointX, pointY);

                    // Вывод результата в формате In/Out
                    if (inside == true) Console.WriteLine("In");
                    else Console.WriteLine("Out");
                }
            }
        }

        public static bool GetPoints(out int firstPointX, out int firstPointY, out int secondPointX, out int secondPointY, 
            out int thirdPointX, out int thirdPointY, out int pointX, out int pointY, bool inside)
        {
            // Считывание координат первой точки из введённой строки
            string[] point1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool check1X = int.TryParse(point1[0], out firstPointX);
            bool check1Y = int.TryParse(point1[1], out firstPointY);
            // Считывание координат второй точки из введённой строки
            string[] point2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool check2X = int.TryParse(point2[0], out secondPointX);
            bool check2Y = int.TryParse(point2[1], out secondPointY);
            // Считывание координат третьей точки из введённой строки
            string[] point3 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool check3X = int.TryParse(point3[0], out thirdPointX);
            bool check3Y = int.TryParse(point3[1], out thirdPointY);
            // Считывание координат тестируемой точки из введённой строки
            string[] newPoint = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool checkX = int.TryParse(newPoint[0], out pointX);
            bool checkY = int.TryParse(newPoint[1], out pointY);

            if (check1X == false || check1Y == false || check2X == false || check2Y == false
                || check3X == false || check3Y == false || checkX == false || checkY == false)
            {
                // Одна или несколько координат введены неверно
                inside = false;
            }
            else
            {
                //Все координаты введены верно
                inside = true;
            }
            return inside;
        }

        public static bool CheckTriangle(int firstPointX, int firstPointY, int secondPointX, int secondPointY, int thirdPointX, int thirdPointY, int pointX, int pointY, bool inside)
        {
            // Вычисление длин сторон заданного треугольника
            double a = Math.Sqrt(Math.Pow((firstPointX - secondPointX), 2) + Math.Pow((firstPointY - secondPointY), 2));
            double b = Math.Sqrt(Math.Pow((secondPointX - thirdPointX), 2) + Math.Pow((secondPointY - thirdPointY), 2));
            double c = Math.Sqrt(Math.Pow((firstPointX - thirdPointX), 2) + Math.Pow((firstPointY - thirdPointY), 2));
            if ((a >= b + c) || (b >= a + c) || (c >= a + b))
            {
                // Большая сторона должна быть меньше суммы двух других
                // Указанный треугольник не существует    
                inside = false;
            }
            else
            {
                // Треугольник существует
                inside = true;
            }
            return inside;
        }

        public static bool CheckPoint(int firstPointX, int firstPointY, int secondPointX, int secondPointY, int thirdPointX, int thirdPointY, int pointX, int pointY)
        {
            bool inside;

            // Проверка принадлежности точки треугольнику через метод относительности
            // Метод использует данные о том, по какую сторону от рассматриваемой прямой лежит рассматриваемая точка
            // Если точка лежит по одну сторону для всех прямых, составляющих треугольник, то она расположена внутри
            double posAB = pointX * (secondPointY - firstPointY) + pointY * (firstPointX - secondPointX) + firstPointY * secondPointX - firstPointX * secondPointY;
            double posBC = pointX * (thirdPointY - secondPointY) + pointY * (secondPointX - thirdPointX) + secondPointY * thirdPointX - secondPointX * thirdPointY;
            double posAC = pointX * (firstPointY - thirdPointY) + pointY * (thirdPointX - firstPointX) + thirdPointY * firstPointX - thirdPointX * firstPointY;

            if ( ( (posAB >= 0) && (posAC >= 0) && (posBC >= 0) ) || ( (posAB <= 0) && (posAC <= 0) && (posBC <= 0) ) ) inside = true;
            else inside = false;

            return inside;
        }
    }
}
