using System;

namespace UP2
{
    class Program
    {
        // Задача 2. https://acmp.ru/index.asp?main=task&id_task=556
        // Найти вероятность существования жизни на Марсе при искажении истины n раз (n – число от 1 до 100), 
        // в каждый из которых вероятность того, что человек соврал, равна p, а сказал правду – q.
        static void Main(string[] args)
        {
            // Представление вещественных чисел через точку, а не через запятую
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            bool ok;
            int n;
            // Ввод количества чисел
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
            } while (!ok || n < 1 || n > 100);

            // Ввод N чисел - вероятностей
            string userNumbers = Console.ReadLine();
            string[] stringNumbers = userNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] doubleNumbers = new double[0];

            for (int i = 0; i < stringNumbers.Length; i++)
            {
                // Увеличение размера текущего массива с использованием вспомогательного массива
                double[] newDoubleNumbers = new double[doubleNumbers.Length + 1];
                doubleNumbers.CopyTo(newDoubleNumbers, 0);
                doubleNumbers = new double[newDoubleNumbers.Length];
                newDoubleNumbers.CopyTo(doubleNumbers, 0);

                // Внесение элемента строкового массива в числовой массив
                ok = double.TryParse(stringNumbers[i], out doubleNumbers[i]);
                if (!ok)
                {
                    // Некорректные данные
                    return;
                }
            }

            double p = 1;
            double q;

            for (int i = 0; i < doubleNumbers.Length; i++)
            {
                // Вычисление вероятности
                q = 1 - p;
                p = p * doubleNumbers[i] + q * (1 - doubleNumbers[i]);
            }

            // Вывод результата с округлением до 6 знаков после запятой
            string res = Math.Round(p, 6).ToString();
            Console.WriteLine(res);
        }
    }
}
