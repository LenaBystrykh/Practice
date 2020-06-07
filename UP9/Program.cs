using System;

namespace UP9
{
    // Задача 9. 18. Выполнить задание, реализовав динамические структуры данных «вручную», без использования коллекций языка C#. 
    // Напишите метод создания двунаправленного списка, в информационные поля элементов которого последовательно заносятся номера с 1 до N (N водится с клавиатуры). 
    // Первый включенный в список элемент, имеющий номер 1, оказывается в голове списка (первым). Разработайте методы поиска и удаления элементов списка.
    public class Program
    {
        static void Main(string[] args)
        {
            int N;
            bool ok;
            Console.WriteLine("Введите N - количество элементов в списке");
            do
            {
                // Проверка ввода, должно быть введено целое положительное число
                ok = int.TryParse(Console.ReadLine(), out N);
                // Если введено не целое положительное число, вывод ошибки 
                if (!ok || N <= 0) Console.WriteLine("Ошибка ввода. Попробуйте снова");
            } while (!ok || N <= 0);

            // Создание двунаправленного связного списка
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            // Заполняем его N элементами
            list.Beg = list.MakeList(N);

            // Переменная для хранения пользовательского выбора
            int choice = -1;
            // Когда пользователь введёт 4, цикл прекратится (Выход)
            while(choice !=4)
            {
                Console.WriteLine("1. Печать");
                Console.WriteLine("2. Поиск элемента");
                Console.WriteLine("3. Удаление элемента");
                Console.WriteLine("4. Выход");

                // Проверка ввода
                ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok || choice < 0 || choice > 4)
                {
                    // Если введено что-то кроме 1,2,3,4 - ошибка ввода
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 0 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        // Печать списка
                        Console.Clear();
                        list.ShowList(list.Beg);
                        break;
                    case 2:
                        Console.Clear();
                        // Поиск элемента 
                        Console.WriteLine("Введите целое число - элемент, который необходимо найти");
                        int number;
                        // Проверка ввода искомого элемента
                        do
                        {
                            ok = int.TryParse(Console.ReadLine(), out number);
                            if (!ok) Console.WriteLine("Ошибка ввода. Попробуйте снова");
                        } while (!ok);
                        // Поиск элемента
                        bool found = list.Search(list.Beg, number);
                        // Если элемент был найден, вывод сообщения об этом
                        if (found == true) Console.WriteLine($"Элемент {number} найден");
                        // Если элемент не был найден, вывод сообщения об этом
                        else Console.WriteLine($"Элемент {number} не найден");
                        break;
                    case 3:
                        Console.Clear();
                        // Удаление элемента
                        Console.WriteLine("Введите целое число - элемент, который необходимо удалить");
                        int del;
                        // Проверка ввода элемента, который необходимо удалить
                        do
                        {
                            ok = int.TryParse(Console.ReadLine(), out del);
                            if (!ok) Console.WriteLine("Ошибка ввода. Попробуйте снова");
                        } while (!ok) ;
                        // Удаление элемента
                        list.Beg = list.Delete(list.Beg, del);
                        break;
                    case 4:
                        // Выход
                        choice = 4;
                        Console.Clear();
                        break;
                }
            }
        }
    }
    // Класс элементов списка
    public class Point<T>
    {
        // Информационное поле
        public T Data { get; set; }
        // Ссылка на следующий элемент
        public Point<T> Next { get; set; }
        // Ссылка на предыдущий элемент
        public Point<T> Pred { get; set; }

        // Конструктор без параметров, все значения по умолчанию
        public Point()
        {
            Next = null;
            Pred = null;
            Data = default(T);
        }

        // Конструктор с параметрами, задано значение информационного поля
        public Point(T data)
        {
            Data = data;
            Next = null;
            Pred = null;
        }

        // Перегрузка ToString для вывода информационного поля
        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }

    // Двунаправленный связный список
    public class DoublyLinkedList<T>
    {
        // Элемент списка, его начало
        public Point<T> Beg { get; set; }

        // Конструктор без параметров, нет начального элемента 
        public DoublyLinkedList()
        {
            Beg = null;
        }

        // Конструктор с параметрами, задан начальный элемент списка
        public DoublyLinkedList(Point<T> data)
        {
            Beg = data;
        }

        // Конструктор с параметрами, начальный элемент - начало другого списка
        public DoublyLinkedList(DoublyLinkedList<T> list)
        {
            Beg = list.Beg;
        }

        // Формирование элемента списка с заданным информационным полем
        public Point<int> MakePoint(int number)
        {
            Point<int> p = new Point<int>(number);
            return p;
        }
        // Формирование двунаправленного списка заданного размера
        public Point<int> MakeList(int size)
        {
            int first = 1;
            int others;
            others = first + 1;
            // Добавление элемента "1" в начало списка
            Point<int> beg = MakePoint(first);

            // Вспомогательный элемент со значением начального
            Point<int> tHelp = beg;

            // Добавление элементов, пока список не будет иметь заданный размер
            for (int i = 1; i < size; i++)
            {
                // Создание элемента со значением others (изначально на 1 больше, чем first)
                Point<int> p = MakePoint(others);
                // Ссылка на следующий элемент для текущего - ссылка на вспомогательный
                p.Next = tHelp;
                // Ссылка на предыдущий элемент для вспомогательного - ссылка на текущий
                tHelp.Pred = p;
                // Значение вспомогательного элемента - текущий элемент
                tHelp = p;
                // Увеличиваем others для перехода к следующему элементу
                others++;
            }
            // После добавления всех элементов возвращаем элемент beg, хранящий ссылки на последующие элементы
            return beg;
        }
        public void ShowList(Point<int> beg)
        {
            // Печать списка
            Console.Clear();
            // Проверка наличия элементов в списке
            if (beg == null)
            {
                // Список пуст
                Console.WriteLine("The List is empty");
                return;
            }
            Point<int> p = beg;
            while (p != null)
            {
                // Печать элемента
                Console.WriteLine(p);
                // Переход к следующему элементу
                p = p.Pred;
            }
            Console.WriteLine();
        }
        public Point<int> Delete(Point<int> beg, int deleteThis)
        {
            // Удаление заданного элемента
            int count = 0;
            // Проверка наличия элементов в списке
            if (beg == null)
            {
                // Список пуст
                Console.WriteLine("The List is empty");
                return beg;
            }
            Point<int> p = beg;
            while (p != null)
            {
                // Если информационное поле текущего элемента списка совпадает с заданным элементом
                if (p.Data == deleteThis)
                {
                    // Увеличиваем переменную count = элемент был найден
                    count++;
                    if (p.Pred == null) // Текущий элемент - последний?
                    {
                        // Удаление ссылки предыдущего элемента на текущий
                        // Обнуление текущего элемента
                        Point<int> tHelp = p.Next;
                        tHelp.Pred = null;
                        p.Next.Pred = null;
                        return beg;
                    }
                    else
                    {
                        if (p.Next == null) // Текущий элемент - первый?
                        {
                            // Удаление ссылки следующего элемента на текущий
                            // Обнуление текущего элемента
                            Point<int> tHelp = p.Pred;
                            tHelp.Next = null;
                            p.Pred.Next = null;
                            p.Next = null;
                            beg = p.Pred;
                            p = p.Pred;
                            return beg;
                        }
                        else
                        {
                            // Текущий элемент находится внутри списка, не первый и не последний
                            // Удаление ссылок предыдущего и следующего элементов на текущий
                            // Обнуление текущего элемента
                            // Ссылка предыдущего элемента на следующий для него = ссылка на следующий элемент для текущего
                            // Ссылка следующего элемента на предыдущий для него = ссылка на предыдущий элемент для текущего
                            Point<int> tHelp1 = p.Pred;
                            Point<int> tHelp2 = p.Next;
                            tHelp1.Next = p.Next;
                            tHelp2.Pred = p.Pred;
                            p.Pred.Next = p.Next;
                            p.Next.Pred = p.Pred;
                            p = p.Pred;
                            return beg;
                        }
                    }
                }
                else
                {
                    // Текущий элемент не совпадает с заданным
                    // Переход к следующему элементу
                    p = p.Pred;
                }
            }
            // Если переменная count не увеличивалась, значит, элемент не был найден
            if (count == 0) Console.WriteLine("Элемент не был найден");
            // Если переменная count изменила значение, значит, элемент был найден и удалён
            else Console.WriteLine("Элемент удалён");
            // Возвращение измененного элемента, хранящего ссылки на остальные
            return beg;
        }
        public bool Search(Point<int> beg, int findThis)
        {
            // Поиск элемента
            bool found = false;
            // Проверка наличия элементов в списке
            if (beg == null)
            {
                // Список пуст
                Console.WriteLine("The List is empty");
                return found;
            }
            Point<int> p = beg;
            while (p != null)
            {
                // Если информационное поле текущего элемента совпадает с искомым, элемент найден
                if (p.Data == findThis)
                {

                    // Элемент найден
                    found = true;
                }
                // Переход к следующему элементу списка
                p = p.Pred;
            }
            // Возвращение результата (true - найден, false - не найден)
            return found;
        }
    }
}
