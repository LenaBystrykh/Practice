using System;

namespace UP3
{
    // Задача 3. №59, А) Даны действительные числа x, y. Определить, принадлежит ли точка с координатами x, y заштрихованной части плоскости.
    // Заштрихованная часть плоскости - окружность радиуса 1 с центром в (0;0)
    public class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            bool res;
            
            // Ввод координат
            Console.WriteLine("Введите значение х");
            x = CheckUserNumber();
            Console.WriteLine("Введите значение y");
            y = CheckUserNumber();

            // Проверка принадлежности точки к области
            res = CheckDia(x, y);

            // Вывод результата
            if (res == true)
                Console.WriteLine("Точка принадлежит заданной области");
            else Console.WriteLine("Точка не принадлежит заданной области");

        }
        public static double CheckUserNumber()
        {
            bool ok;
            double n;

            // Проверка ввода вещественного числа
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Ошибка ввода. Повторите попытку");
            } while (!ok);
            return n;
        }
        public static bool CheckDia(double x, double y)
        {
            bool res;

            // Проверка принадлежности заданной области
            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1)
            {
                res = true;
            }
            else res = false;
            return res;
        }
    }
}
