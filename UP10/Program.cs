using System;

namespace UP10
{
    // Задача 10. №531. Выполнить задание, реализовав динамические структуры данных «вручную», без использования коллекций языка C#. 
    // Даны натуральное число n, действительные числа x_1, … ,x_n (n ≥ 2). Получить последовательность x_1 - x_n, x_2 - x_n, … ,x_(n-1) - x_n.
    public class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества элементов с проверкой
            int n;
            n = CheckInt();
            // Создание и печать списка из n элементов
            LinkedList<double> list = new LinkedList<double>();
            list.Beg = list.MakeList(n);
            Point<double> beg = list.Beg;
            Console.WriteLine("Сформированный список: ");
            list.ShowList(list.Beg);
            // Получение последнего элемента списка
            double Xn = GetXn(list, n);
            Console.WriteLine();
            //Создание и печать нового списка со значениями элементов на Xn меньше, чем в исходном списке
            LinkedList<double> newList = new LinkedList<double>();
            newList.Beg = MakeNewList(list, n, Xn);
            Console.WriteLine("Новый список: ");
            newList.ShowList(newList.Beg);
        }
        // Проверка ввода
        public static int CheckInt()
        {
            int d;
            bool ok;
            Console.WriteLine("Введите количество действительных чисел в списке");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out d);
                if (!ok) Console.WriteLine("Ошибка ввода. Необходимо ввести целое число");
                if (d < 2) Console.WriteLine("Ошибка ввода. Необходимо ввести число >= 2");
            } while (!ok || d < 2);

            return d;
        }
        // Получение последнего элемента сгенерированного списка
        public static double GetXn(LinkedList<double> list, int n)
        {
            Point<double> p = list.Beg;
            // Пока "номер" элемента меньше, чем количество элементов, и следующий (т.к. проверка выполняется после присвоения p = p.Next) элемент непустой, происходит переход к следующему элементу
            // Когда элементы закончились, возвращаем информационное поле элемента p - последнего элемента
            for (int i = 1; i < n && p != null; i++)
                p = p.Next;
            return (double)p.Data;
        }
        // Создание нового списка (в котором все элементы будут на {значение последнего элемента} меньше, чем в исходном списке)
        public static Point<double> MakeNewList(LinkedList<double> list, int n, double Xn)
        {
            // Создание элемента со значением начального элемента исходного списка, он будет перемещаться и изменяться
            Point<double> p = list.Beg;
            // Создание начального элемента нового списка со значением вышесозданного элемента
            Point<double> beg = p;
            // Пока элемент непустой и следующий элемент непустой (все элементы, кроме последнего)
            while (p != null && p.Next != null)
            {
                // Удаление последнего элемента и ссылки на него
                if (p.Next.Next == null)
                {
                    p.Next = null;
                }
                // Уменьшение значения элемента на значение последнего элемента исходного списка (Xn)
                p.Data = (double)p.Data - Xn;
                // Переход к следующему элементу
                p = p.Next;    
            }
            // Возвращение начального элемента нового списка, хранящего ссылки на остальные элементы
            return beg;
        }
    }
    // Класс элемента списка
    public class Point<T>
    {
        // Информационное поле
        public object Data { get; set; }
        // Ссылка на следующий элемент списка
        public Point<T> Next { get; set; }
        // Конструктор без параметров, значения полей по умолчанию
        public Point()
        {
            Next = null;
            Data = default(T);
        }
        // Конструктор с параметрами, задаётся информационное поле
        public Point(T data)
        {
            Data = data;
            Next = null;
        }
        // Конструктор с параметрами, информационное поле генерируется случайно 
        public Point(Random rnd)
        {
            // Генерация случайного действительного числа от 0 до 20 с округлением до 2 знаков после запятой
            double n = Math.Round((rnd.NextDouble() * 20), 2);
            Data = n;
            Next = null;
        }
        // Перегрузка ToString для печати информационного поля
        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }
    // Класс связного списка
    public class LinkedList<T>
    {
        // Начальный элемент списка
        public Point<T> Beg { get; set; }
        // Конструктор без параметров, начального элемента нет
        public LinkedList()
        {
            Beg = null;
        }
        // Конструктор с параметрами, задаётся начальный элемент
        public LinkedList(Point<T> data)
        {
            Beg = data;
        }
        // Конструктор с параметрами, начальный элемент равен начальному элементу другого списка
        public LinkedList(LinkedList<T> list)
        {
            Beg = list.Beg;
        }
        // Конструктор с параметрами, задаётся размер списка, генерируется случайный список заданного размера
        public LinkedList(int size)
        {
            this.Beg = this.MakeList(size);
        }
        // Конструктор с параметрами, начальный элемент генерируется случайно
        public LinkedList(Random rnd)
        {
            Point<T> p = new Point<T>(rnd);
            Beg = p;
        }
        // Создание элемента списка с заданным информационным полем
        public Point<T> MakePoint(T num)
        {
            Point<T> p = new Point<T>(num);
            return p;
        }
        // Создание элемента списка со случайным информационным полем
        public Point<T> MakePoint(Random rnd)
        {
            Point<T> p = new Point<T>(rnd);
            return p;
        }
        // Создание списка заданного размера через добавление в начало
        public Point<T> MakeList(int size)
        {
            Random rnd = new Random();
            // Создание первого элемента
            Point<T> beg = MakePoint(rnd);
            for (int i = 1; i < size; i++)
            {
                // Создание элемента и добавление в начало списка
                Point<T> p = MakePoint(rnd);
                p.Next = beg;
                beg = p;
            }
            return beg;
        }
        // Печать списка
        public void ShowList(Point<T> Beg)
        {
            // Проверка наличия элементов в списке
            if (Beg == null)
            {
                // Список пуст
                Console.WriteLine("The List is empty");
                return;
            }
            Point<T> p = Beg;
            while (p != null)
            {
                // Печать элемента
                Console.WriteLine(p);
                // Переход к следующему элементу
                p = p.Next;
            }
            Console.WriteLine();
        }
    }
}
