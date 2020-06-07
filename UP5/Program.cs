using System;

namespace UP5
{
    // Задача 5. №398. Ддана действительная квадратная матрица порядка n. Рассмотрим те элементы, которые расположены в строках, начинающихся с отрицательного элемента. 
    // Найти суммы тех из них, которые расположены соответственно ниже, выше и на главной диагонали.
    public class Program
    {
        static void Main(string[] args)
        {
            // Переменные для хранения суммы элементов выше главной диагонали, ниже неё и соответственно на ней
            double upSumm, downSumm, eqSumm;

            // Проверка пользовательского ввода размерности матрицы
            int N = ReadN();

            // Создание квадратной матрицы порядка n
            double[,] matrix = new double[N, N];
            // Заполнение матрицы случайными вещественными числами
            matrix = GenerateMatrix(N, matrix);
            // Вывод сформированной матрицы на экран
            PrintMatrix(N, matrix);

            // Подсчёт необходимых сумм
            GetSumm(N, matrix, out upSumm, out downSumm, out eqSumm);
            Console.WriteLine();
            //Вывод результатов
            Console.WriteLine("Сумма элементов выше главной диагонали, находящихся в строках, начинающихся с отрицательных элементов = " + upSumm);
            Console.WriteLine("Сумма элементов ниже главной диагонали, находящихся в строках, начинающихся с отрицательных элементов = " + downSumm);
            Console.WriteLine("Сумма элементов на главной диагонали, находящихся в строках, начинающихся с отрицательных элементов = " + eqSumm);

        }
        public static int ReadN()
        {
            bool ok;
            int N;
            // Проверка ввода размерности - целое неотрицательное число >=2
            Console.WriteLine("Введите размерность квадратной матрицы - целое число");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out N);
                if (!ok) Console.WriteLine("Ошибка ввода, повторите попытку");
                if (N < 2) Console.WriteLine("Матрица не может содержать меньше 2 строк и столбцов");
            } while (!ok || N < 2);
            return N;
        }
        public static double[,] GenerateMatrix(int N, double[,] matrix)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // Генерация случайных вещественных чисел от -20 до 20 с 2 знаками после запятой
                    matrix[i, j] = Math.Round((rnd.NextDouble() * 40 - 20), 2);                 
                }
            }
            return matrix;
        }
        public static void PrintMatrix(int N, double[,] matrix)
        {
            Console.WriteLine();
            Console.WriteLine("Полученная матрица:");
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // Вывод каждого элемента строки
                    Console.Write(matrix[i, j] + " ");
                }
                // Переход на следующую строку
                Console.WriteLine();
            }
        }
        public static void GetSumm(int N, double[,] matrix, out double upSumm, out double downSumm, out double eqSumm)
        {
            upSumm = 0; 
            downSumm = 0; 
            eqSumm = 0;
            for (int i = 0; i < N; i++)
            {
                // Рассматриваем те строки, в которых первый элемент - отрицательный
                if (matrix[i,0] < 0)
                {
                    // В этих строках рассматриваем каждый элемент
                    for (int j = 0; j < N; j++)
                    {
                        // Если номер строки больше, чем номер столбца - элементы расположены ниже главной диагонали
                        if (i > j)
                        {
                            // Увеличиваем сумму элементов ниже главной диагонали на значение текущего элемента
                            downSumm += matrix[i, j];
                        }
                        else
                        {
                            // Если номер строки меньше, чем номер столбца - элементы расположены выше главной диагонали
                            if (i < j)
                            {
                                // Увеличиваем сумму элементов выше главной диагонали на значение текущего элемента
                                upSumm += matrix[i, j];
                            }
                            else
                            {
                                // Если номер строки равен номеру столбца - элементы расположены на главной диагонали
                                if (i == j)
                                {
                                    // Увеличиваем сумму элементов на главной диагонали на значение текущего элемента
                                    eqSumm += matrix[i, j];
                                    // Повторяем весь цикл, перебирая все строки матрицы
                                    // Передаём полученные суммы как параметры с указанием out
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
