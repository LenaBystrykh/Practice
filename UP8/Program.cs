using System;

namespace UP8
{
    // Задача 8. 10. Граф задан матрицей смежности. Найти все его мосты.
    public class Program
    {
        // Присвоение значения порядку матрицы
        public static int n = 5;
        // Создание матрицы заданного порядка
        public static int[,] matrix = CreateMatrix(n);
        // Объявление переменных для поиска в глубину 
        // (чтобы не приходилось передавать их как параметры и упростить рекурсивный вызов функции)
        public static int timer;
        public static int[] tin = new int[n];
        public static int[] fup = new int[n];
        public static bool[] used = new bool[n];
        public static string[] bridges = new string[n];
        static void Main(string[] args)
        {
            // Печать сформированной матрицы
            PrintMatrx(matrix, 5);
            // Поиск мостов в матрице
            FindBridges();
        }
        public static int[,] CreateMatrix(int n)
        {
            Random rnd = new Random();
            int[,] matrix = new int[n, n];

            // Заполнение главной диагонали и элементов, расположенных выше неё
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Заполнение элементов главной диагонали нулями
                    if (i == j) matrix[i, j] = 0;
                    else
                    {
                        if (i < j)
                        {
                            // Так как нужна матрица смежности, генерируются случайные числа 1 или 0
                            // 0 - отсутствие ребра, 1 - есть ребро
                            matrix[i, j] = rnd.Next(0, 2);
                        }
                    }
                }
            }

            // Матрица смежности симметрична относительно главной диагонали, поэтому дублируем элементы
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i > j)
                    {
                        matrix[i, j] = matrix[j, i];
                    }
                }
            }
            return matrix;
        }
        public static void PrintMatrx(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void DeepSearch(int v, int p = -1)
        {
            int to;
            // Отмечаем вершину v как used = над ней действия уже выполнены
            used[v] = true;
            tin[v] = fup[v] = timer++;
            for (int i = 0; i < n; ++i)
            {
                // Если элемент матрицы = 1, то есть из него есть ребро
                // (Иначе элемент не может содержать мост, так что рассматривать его смысла нет)
                if (matrix[v, i] == 1)
                {
                    to = i;
                    if (to == p) continue;
                    // Если в этой вершине уже были, берём минимальное время
                    if (used[to])
                    {
                        fup[v] = Math.Min(fup[v], tin[to]);
                    }
                    else
                    {
                        // Если в вершине не были, то рекурсия - выполняем все действия этой функции уже для новой вершины
                        DeepSearch(to, v);
                        // Берём минимальное время
                        fup[v] = Math.Min(fup[v], fup[to]);
                        // Если время для рассматриваемой точки больше, чем время для точки, для которой изначально выполнялась функция, то есть мост, соединяющий эти точки
                        if (fup[to] > tin[v])
                        {
                            bridges[v] = "Мост из " + (v + 1) + " в " + (to + 1);
                            Console.WriteLine($"Мост из {v + 1} в {to + 1}");
                        }
                    }
                }
            }
        }
        public static void FindBridges()
        {
            timer = 0;
            for (int i = 0; i < n; ++i)
            {
                // Отмечаем все вершины как непросмотренные
                used[i] = false;
            }
            for (int i = 0; i < n; ++i)
            {
                // Для всех непросмотренных вершин выполняем поиск в глубину
                if (!used[i]) DeepSearch(i);
            }
        }
    }
}
