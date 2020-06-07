using System;

namespace UP7
{
    // Задача 7. 9. Доопределить заданную булеву функцию всеми возможными способами так, чтобы она была монотонной.
    // Выписать все вектора в лексикографическом порядке.
    public class Program
    {
        static void Main(string[] args)
        {
            // Ввод функции
            string input;
            input = CheckInput("Введите булеву функцию, заданную вектором значений. Для ввода используйте 0, 1 и *");
            // Строка, содержащая информацию о том, что функция никогда не может быть монотонной, если это так
            string never;
            // Проверка на немонотонность
            CheckNotMonotone(input, out never);
            // Если строка содержит информацию о том, что функция никогда не может быть монотонной, завершение работы
            if (never.Contains("никогда"))
            {
                return;
            }
            else
            {
                // Если функцию можно доопределить, доопределение и вывод всех способов
                string output = ChangeIfPossible(input);
                Console.WriteLine("Все возможные способы доопределения: ");
                MakeAnswer(output);
            }
        }
        // Проверка ввода
        public static string CheckInput(string s)
        {
            Console.WriteLine(s);
            string input;
            input = Console.ReadLine();
            // Вычисление количества введённых символов
            int n = input.Length;

            // Проверка ввода
            for (int i = 0; i < n; i++)
            {
                // Если введённый символ соответствует одному из перечисленных (0, 1, *), ввод корректен
                if (input[i] == '0' || input[i] == '1' || input[i] == '*')
                {
                    // Ввод корректен
                }
                // Если присутствует что-либо другое, ввод некорректен
                else
                {
                    // Ввод некорректен
                    Console.WriteLine("Ввод некорректен, попробуйте снова");
                    // Повторный ввод функции
                    input = Console.ReadLine();
                    // Вычисление новой длины
                    n = input.Length;
                    // Обнуление индекса для проверки новой функции (-1, так как следующим действием в цикле будет i++)
                    i = -1;
                }
            }

            int two = n;
            // Проверка, что функция корректной длины
            do
            {
                if (two % 2 != 0)
                {
                    do
                    {
                        Console.WriteLine("Функция задана неверно. Количество введённых цифр должно быть степенью двойки");
                        input = Console.ReadLine();
                        n = input.Length;
                        two = n;
                    } while (two % 2 != 0);
                }
                two = two / 2;
            } while (two > 1);

            return input;
        }
        // Проверка немонотонности
        public static void CheckNotMonotone(string input, out string never)
        {
            int n = input.Length;
            for (int i = 0; i < n; i++)
            {
                // Рассмотрение только единиц, потому что для нулей любые следующие значения не будут влиять на монотонность
                if (input[i] == '1' && (i < n / 2))
                {
                    // Условие немонотонности
                    if (input[(n / 2) + i] == '0')
                    {
                        never = "Данная функция никогда не может быть монотонной";
                        Console.WriteLine(never);
                        return;
                    }
                }
            }
            never = "";
        }
        // Замена * на 0 или 1, если это однозначно возможно
        public static string ChangeIfPossible(string input)
        {
            int n = input.Length;
            // Генерация результирующего массива, дублирующего введённую функцию
            char[] output = new char[n];
            output = input.ToCharArray();
            for (int i = 0; i < n; i++)
            {
                // Проверка однозначных вариантов и замена * на необходимую цифру
                if (output[i] == '*' && (i < n / 2))
                {
                    // Если соответствующий следующий элемент = 0, то монотонность сохранится только при текущем нуле
                    if (input[(n / 2) + i] == '0')
                    {
                        output[i] = '0';
                    }
                }
                if (output[i] == '*' && (i >= n / 2))
                {
                    // Если соответствующий предыдущий элемент = 1, то монотонность сохранится только при текущей единице
                    if (input[i - (n / 2)] == '1')
                    {
                        output[i] = '1';
                    }
                }
            }
            // Возвращение строки с заменёнными однозначно доопределяющимися *
            string result = null;
            for (int i = 0; i < n; i++)
            {
                result += output[i];
            }
            return result;
        }
        // Для неоднозначно доопределяемых * (когда допустим как 0, так и 1, без влияния на монотонность функции)
        // Генерация матрицы всех возможных наборов значений *
        public static int[,] MatrixOfOptions(string input, int count)
        {
            // Количество способов доопределения для n * = 2^n
            int countOptions = (int)Math.Pow(2, count);
            // Генерация матрицы
            int[,] options = new int[countOptions, count];
            // Переменная для задания количества вариантов, в течение которых 0 будет сохраняться (или 1 будет сохраняться)
            int x;
            for (int i = 0; i < count; i++)
            {
                int j = 0;
                // Переменная для смены нулей и единиц в необходимых местах (1 = true, 0 = false)
                bool ok = false;
                x = (int)(countOptions / Math.Pow(2, i + 1));
                while (j < countOptions)
                {
                    for (int k = j; k < j + x; k++)
                    {
                        if (ok) options[k, i] = 1; else options[k, i] = 0;
                    }
                    ok = !ok;
                    j += x;
                }
            }
            return options;
        }
        // Вывод результатов
        public static void MakeAnswer(string input)
        {
            // Подсчёт звёздочек - позиций, которые нужно доопределить
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    count++;
                }
            }

            // Запоминание позиций, на которых расположены *, для дальнейшего доопределения
            int[] indexes = new int[count];
            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    indexes[index] = i;
                    index++;
                }
            }
            // Генерация матрицы всех значений *
            int countOptions = (int)Math.Pow(2, count);
            int[,] options = new int[countOptions, count];
            options = MatrixOfOptions(input, count);
            
            // Подстановка значений * в нужные места и вывод результатов
            string output = input;
            for (int i = 0; i < countOptions; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    string f = options[i, j].ToString();
                    output = output.Remove(indexes[j], 1).Insert(indexes[j], f);
                }
                Console.WriteLine(output);
            }
        }
    }
}
