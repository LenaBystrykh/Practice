using System;
using System.Collections.Generic;
using System.Linq;

namespace UP12
{
    // Задача 12. 4, 7. Выполнить сравнение двух предложенных методов сортировки одномерных массивов (сортировка слиянием, блочная сортировка), 
    // содержащих n элементов, по количеству пересылок и сравнений. 
    // Провести анализ методов сортировки для трех массивов: упорядоченного по возрастанию, упорядоченного по убыванию и неупорядоченного. 
    // Все три массива следует отсортировать обоими методами сортировки.
    public class Program
    {
        static void Main(string[] args)
        {
            int resend = 0; int compare = 0;
            int[] array1, array2, array3;
            CreateArrays(15, out array1, out array2, out array3);
            Print(array1, "Неупорядоченный массив: ");
            Print(array2, "Упорядоченный по возрастанию массив: ");
            Print(array3, "Упорядоченный по убыванию массив: ");

            int[] m_array1 = new int[array1.Length];
            int[] m_array2 = new int[array2.Length];
            int[] m_array3 = new int[array3.Length];
            Console.WriteLine();
            Console.WriteLine("Массивы после сортировки СЛИЯНИЕМ");
            Console.WriteLine();
            resend = 0;  compare = 0;
            m_array1 = MergeSort(array1, compare, out compare, resend, out resend);
            Print(m_array1, "Неупорядоченный массив: ");
            Console.WriteLine($"Количество пересылок = {resend}, количество сравнений = {compare}");
            resend = 0; compare = 0;
            m_array2 = MergeSort(array2, compare, out compare, resend, out resend);
            Print(m_array2, "Упорядоченный по возрастанию массив: ");
            Console.WriteLine($"Количество пересылок = {resend}, количество сравнений = {compare}");
            resend = 0; compare = 0;
            m_array3 = MergeSort(array3, compare, out compare, resend, out resend);
            Print(m_array3, "Упорядоченный по убыванию массив: ");
            Console.WriteLine($"Количество пересылок = {resend}, количество сравнений = {compare}");

            Console.WriteLine();

            int[] b_array1 = new int[array1.Length];
            int[] b_array2 = new int[array2.Length];
            int[] b_array3 = new int[array3.Length];
            Console.WriteLine();
            Console.WriteLine("Массивы после БЛОЧНОЙ сортировки");
            Console.WriteLine();
            b_array1 = BucketSort(array1, out resend, out compare);
            Print(b_array1, "Неупорядоченный массив: ");
            Console.WriteLine($"Количество пересылок = {resend}, количество сравнений = {compare}");
            b_array2 = BucketSort(array2, out resend, out compare);
            Print(b_array2, "Упорядоченный по возрастанию массив: ");
            Console.WriteLine($"Количество пересылок = {resend}, количество сравнений = {compare}");
            b_array3 = BucketSort(array3, out resend, out compare);
            Print(b_array3, "Упорядоченный по убыванию массив: ");
            Console.WriteLine($"Количество пересылок = {resend}, количество сравнений = {compare}");
        }
        // Генерация массивов
        public static void CreateArrays(int n, out int[] array1, out int[] array2, out int[] array3)
        {
            Random rnd = new Random();
            // Неупорядоченный массив
            array1 = new int[n];
            // Отсортированный по возрастанию массив
            array2 = new int[n];
            // Отсортированный по убыванию массив
            array3 = new int[n];

            // Заполнение первого массива случайными числами
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = rnd.Next(1, 50);
            }

            // Заполнение второго массива элементами из первого и сортирова
            array1.CopyTo(array2, 0);
            Array.Sort(array2);

            // Заполнение третьего массива элементами второго в обратном порядке
            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = array2[array2.Length - 1 - i];
            }
        }
        // Печать массива
        public static void Print(int[] array, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        // Сортировка слиянием
        public static int[] MergeSort(int[] array, int compare_previous, out int compare, int copy_operations_prev, out int copy_op)
        {
            // Присвоение переменным, подсчитывающим количество сравнений и пересылок, предыдущих значений аналогичных переменных
            // Пересылок в сортировке слиянием быть не может, так что подсчитывается количество копирований элементов
            compare = compare_previous;
            copy_op = copy_operations_prev;
            if (array.Length == 1)
            {
                return array;
            }
            // Нахождение середины массива
            int middle = array.Length / 2;
            copy_op++;
            // Переход к функции Merge, как первый массив рассматривается первая половина массива, как второй массив - вторая половина
            return Merge(MergeSort(array.Take(middle).ToArray(), compare, out compare, copy_op, out copy_op), MergeSort(array.Skip(middle).ToArray(), compare, out compare, copy_op, out copy_op), compare, out compare, copy_op, out copy_op);
        }
        // Сортировка слиянием
        public static int[] Merge(int[] arr1, int[] arr2, int compare_previous, out int compare, int copy_operations_prev, out int copy_op)
        {
            int ptr1 = 0, ptr2 = 0;
            // Присвоение переменным, подсчитывающим количество сравнений и пересылок, предыдущих значений аналогичных переменных
            // Пересылок в сортировке слиянием быть не может, так что подсчитывается количество копирований элементов
            compare = compare_previous;
            copy_op = copy_operations_prev;
            // Происходит "слияние" двух массивов
            int[] merged = new int[arr1.Length + arr2.Length];
            
            for (int i = 0; i < merged.Length; ++i)
            {
                copy_op++;
                if (ptr2 < arr2.Length && ptr1 < arr1.Length)
                {
                    compare++;
                    if (arr1[ptr1] > arr2[ptr2] && ptr2 < arr2.Length)
                        merged[i] = arr2[ptr2++];
                    else
                        merged[i] = arr1[ptr1++];
                }
                else
                {
                    if (ptr2 < arr2.Length)
                        merged[i] = arr2[ptr2++];
                    else
                        merged[i] = arr1[ptr1++];
                }
            }
            return merged;
        }
        // Блочная сортировка
        public static int[] BucketSort(int[] array, out int resend, out int compare)
        {
            resend = 0; compare = 0;
            // Генерация массива блоков (количество блоков равно количеству элементов в исходном массиве)
            List<int>[] aux = new List<int>[array.Length];

            // Инициализация каждого блока
            for (int i = 0; i < aux.Length; ++i)
                aux[i] = new List<int>();

            // Поиск максимального и минимального значений в исходном массиве
            int minValue = array[0];
            int maxValue = array[0];

            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] < minValue)
                {
                    compare++;
                    minValue = array[i];
                }
                else if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    compare++;
                }
            }

            // Разница максимального и минимального значений (диапазон)
            double numRange = maxValue - minValue;

            for (int i = 0; i < array.Length; ++i)
            {
                // Вычисление индекса блока
                int bucketIndex = (int)Math.Floor((array[i] - minValue) / numRange * (aux.Length - 1));

                // Добавление элемента в соответствующий блок
                aux[bucketIndex].Add(array[i]);
            }

            int temp;
            // Сортировка блоков
            for (int i = 0; i < aux.Length; ++i)
            {
                // Сортировка aux[i]
                for (int j = 0; j < aux[i].Count-1; j++)
                {
                    for (int k = j+1; k < aux[i].Count; k++)
                    {
                        compare++;
                        if (aux[i][j] > aux[i][k])
                        {
                            temp = aux[i][j];
                            aux[i][j] = aux[i][k];
                            aux[i][k] = temp;
                            resend++;
                        }
                    }
                }
            }    

            // Помещение отсортированных элементов обратно в исходный массив
            int index = 0;

            for (int i = 0; i < aux.Length; ++i)
            {
                for (int j = 0; j < aux[i].Count; ++j)
                {
                    array[index++] = aux[i][j];
                    resend++;
                }
            }
            return array;
        }
    }
}
