using System;

namespace PractiсeTask7
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Добро пожаловать в приложение по генерации сочетаний из N элементов по K без повторений!");

            // Ввод количества элементов
            Console.WriteLine("\nВведите количество элементов для сочетаний");
            int n = Input(1, 100);

            // Ввод длины сочетаний
            Console.WriteLine($"\nВведите длину сочетаний - от 1 до {n}");
            int k = Input(1, n);

            // Максиммальный возможный элемент
            int max = n - 1;

            // Массив для представления сочетания
            int[] combination = new int[k];
            for (int i = 0; i < k; i++)
                combination[i] = i;

            // Вывод сочетаний из N элементов по K
            Console.WriteLine("\nВозможные сочетания без повторений:");
            bool check;
            do
            {
                // Выводим комбинацию
                PrintCombination(combination);
                // Проверяем существование другой комбинации
                check = ThereAreOtherOptions(combination, max);
                // Если следующая комбинация есть, создаем ее
                if (check)
                    MakeNextCombination(combination, max);
            } while (check); // Выводим комбинации, пока есть возможность создания других комбинаций

            Console.WriteLine("\nЗавершение работы в приложении по генерации сочетаний из N элементов по K без повторений");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        // Печать найденной комбинации
        private static void PrintCombination(int[] comb)
        {
            for (int i = 0; i < comb.Length; i++)
                Console.Write($"{comb[i]} ");

            Console.WriteLine();
        }

        // Проверка, есть ли еще возможные комбинации
        public static bool ThereAreOtherOptions(int[] comb, int max)
        {
            // Изначально мы не знаем, есть ли следующая комбинация
            bool isExist = false;
            int i = 0;

            // Проверяем, пока не дойдем до конца массива или не найдем последней комбинации
            while (!isExist && i < comb.Length)
            {
                if (comb[i] == max - comb.Length + ++i)
                    isExist = false;
                else
                    isExist = true;
            }
            return isExist;
        }

        // Генерация следующей комбинации
        public static void MakeNextCombination(int[] comb, int max)
        {
            // Выбираем последний элемент
            int i = comb.Length - 1;

            // Если элемент является максимально возможным, то выбираем предыдущий элемент
            while (comb[i] == max - comb.Length + 1 + i)
                i--;

            // Увеличиваем элемент
            comb[i]++;

            // Увеличиваем последующие элементы
            for (i += 1; i < comb.Length; i++)
                comb[i] = comb[i - 1] + 1;
        }

        // Ввод целого числа с ограничениями
        private static int Input(int min, int max)
        {
            int number;
            bool check;
            do
            {
                Console.Write("Ввод: ");
                check = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
                if (!check) Console.WriteLine($"Ошибка! Введите целое число от {min} до {max} (включительно)");
            } while (!check);
            return number;
        }
    }
}
