using System;

namespace UP6
{
    // Задача 6. 11. используя рекурсию, реализовать программу. Ввести а₁, а₂, а₃, N, E. Построить последовательность чисел а_k = a_(k-1) + 2*a_(k-2)*a_(k-3). 
    // Найти первые ее N элементов, такие что | a_k-a_(k-1) | > E. Напечатать последовательность, выделить искомые элементы и их номера.
    public class Program
    {
        public static int a1;
        public static int a2;
        public static int a3;
        public static int n;
        public static int e;
        static void Main(string[] args)
        {
            bool ok;
            // Ввод необходимых данных с проверкой
            a1 = CheckInt("Введите первый элемент последовательности");
            a2 = CheckInt("Введите второй элемент последовательности");
            a3 = CheckInt("Введите третий элемент последовательности");
            n = CheckInt("Введите количество искомых элементов");
            // Проверка ввода количества - число должно быть положительным
            if (n < 0)
            {
                Console.WriteLine("Ошибка ввода. Попробуйте снова");
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out n);
                    if (!ok || n < 1) Console.WriteLine("Ошибка ввода. Попробуйте снова");
                } while (!ok || n < 1);
            }    
            e = CheckInt("Введите число, которое должно быть меньше разности искомых элементов с предыдущими");

            // Массив, содержащий все элементы последовательности
            long[] allElements = new long[2];
            // Изначально заполняем только первыми двумя элементами, так как может быть ситуация, когда нужны только они, а остальные нет
            allElements[0] = a1;
            allElements[1] = a2;

            // Массив, содержащий искомые элементы
            long[] nesElements = new long[n];

            // Массив, содержащий номера искомых элементов
            int[] numbersOfElements = new int[n];

            // Обработка входных данных и генерация всех последовательностей
            allElements = MakeArray(allElements, nesElements, numbersOfElements, out nesElements, out numbersOfElements);

            // Вывод результатов
            Print(allElements, nesElements, numbersOfElements);
        }

        public static int CheckInt(string s)
        {
            Console.WriteLine(s);
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Ошибка ввода. Попробуйте снова");
            } while (!ok);
            return n;
        }
        public static long GetElement(int k)
        {
            // Рекурсивное вычисление элементов последовательности
            if (k == 1) return (long)a1;
            if (k == 2) return (long)a2;
            if (k == 3) return (long)a3;
            return (GetElement(k - 1) + 2 * GetElement(k - 2) * GetElement(k - 3));
        }
        public static long[] MakeArray(long[] allElements, long[] nesElements, int[] numbersOfElements, out long[] elements, out int[] numbers)
        {
            int i = 2;
            int n_all = n;
            int pos = 0;
            do
            {
                // Если номер элемента > 2, то есть в массив необходимо добавить новые элементы
                if (i > 2)
                {
                    // Необходимо увеличить размер массива. Для этого используется вспомогательный массив размером на 1 элемент больше
                    long[] allElements_help = new long[allElements.Length + 1];
                    allElements.CopyTo(allElements_help, 0);
                    allElements = new long[allElements_help.Length];
                    allElements_help.CopyTo(allElements, 0);
                }
                // Добавляем рекурсивно вычисленный элемент в массив всех элементов
                allElements[i-1] = GetElement(i);

                // Если условие выполняется, то элемент относится к искомым
                if (Math.Abs(GetElement(i) - GetElement(i - 1)) > e)
                {
                    // Добавляем элемент в массив искомых элементов
                    nesElements[pos] = GetElement(i);

                    // Добавляем номер элемента в массив номеров искомых элементов
                    numbersOfElements[pos] = i;

                    // Увеличиваем количество найденных элементов
                    pos++;
                    // Уменьшаем количество элементов, которые нужно найти
                    n_all--;
                }
                // Переходим к следующему элементу
                i++;
                //Выполняем до тех пор, пока количество элементов, которое нужно найти, не равно нулю
            } while (n_all != 0);

            // Дублируем массив с искомыми элементами для передачи его как параметр
            elements = new long[nesElements.Length];
            nesElements.CopyTo(elements, 0);

            // Дублируем массив с номерами искомых элементов для передачи его как параметр
            numbers = new int[numbersOfElements.Length];
            numbersOfElements.CopyTo(numbers, 0);

            return allElements;
        }
        public static void Print(long[] allElements, long[] nesElements, int[] numbersOfElements)
        {
            Console.WriteLine();
            for (int i = 0; i < allElements.Length; i++)
            {
                Console.Write(allElements[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Искомые элементы: ");
            for (int i = 0; i < nesElements.Length; i++)
            {
                Console.Write(nesElements[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Их номера: ");
            for (int i = 0; i < numbersOfElements.Length; i++)
            {
                Console.Write(numbersOfElements[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
