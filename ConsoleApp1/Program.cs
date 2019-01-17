using System;
using static System.Console;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Мистер Фокс написал на доске все пятизначные числа, сумма цифр которых равна 30. Мистер Форд стёр все числа, кроме тех, у которых есть две одинаковые цифры, а остальные отличаются как от них, так и между собой. Например, мистер Форд стёр число 98751, так как в нём нет одинаковых цифр, и число 88851, так как в нём 3 одинаковые цифры. \r\nЧему равно самое маленькое число, оставшееся на доске?\r\n");
            WriteLine();

            WriteLine("Давайте решим задачку!");
            ReadLine();

            // 1 перебираем все 5-ти значные числа
            //WriteLine("1. Переберем ВСЕ пятизначные числа.");
            //WriteLine("И оставим только те, сумма цифр которых равна 30.");
            WriteLine("1. Переберем ВСЕ пятизначные числа. И оставим только те, сумма цифр которых равна 30.");
            ReadLine();
            // думаем ))))
            Thinking();
            WriteLine("Всего 2588 чисел! Нехилая доска у Фокса! )))\r\n");
            ReadLine();

            WriteLine("Теперь оставим только те числа, в которыйх есть пара одинаковых цифер:");
            ReadLine();
            // думаем ))))
            Thinking();
            int count = 0;
            for (int n = 10000; n < 100000; n++)
            {
                //if (AmountThirty(n))
                if (AmountThirtyAndCouple(n))
                {
                    count++;
                    if (count % 10 == 0)
                    {
                        WriteLine(n);
                    }
                    else
                        Write(n + "\t");
                }
            }

            WriteLine();
            WriteLine();
            WriteLine($"Осталось {count} числа. Тоже не мало!");

            ReadLine();
            WriteLine("Нам нужно только выбрать самое мальенькое. А так как мы перебирали числа по-порядку, то перове и будет самым мальеньким. Поднимись выше и посмотри.");
            WriteLine();
            ReadLine();

            WriteLine("Правильный ответ: 13899");
            ReadLine();
        }

        private static bool AmountThirty(int N)
        {
            // проверить на пятизначность
            if (N < 10000 || N > 99999)
                return false;


            byte[] fiveNumbers = new byte[5];
            // разобрать по числам
            // например 45791
            fiveNumbers[0] = (byte)(N / 10000);         // 4
            /*
            int a = 10000 * fiveNumbers[0];             // 40000
            N -= a;                                     // 45791-40000=5791

            fiveNumbers[1] = (byte)(N / 1000);          // 5
            a = 1000 * fiveNumbers[1];                  // 5000
            N -= a;                                     // 5791-5000=791

            fiveNumbers[2] = (byte)(N / 100);           // 7
            a = 100 * fiveNumbers[2];                   // 700
            N -= a;                                     // 791-700=91
            */
            N %= 10000;                                 // 5791
            fiveNumbers[1] = (byte)(N / 1000);          // 5
            N %= 1000;                                  // 791
            fiveNumbers[2] = (byte)(N / 100);           // 7
            N %= 100;                                   // 91
            fiveNumbers[3] = (byte)(N / 10);            // 9
            fiveNumbers[4] = (byte)(N % 10);            // 1

            if (fiveNumbers[0] + fiveNumbers[1] + fiveNumbers[2] + fiveNumbers[3] + fiveNumbers[4] == 30)
                return true;
            else
                return false;
        }

        private static bool AmountThirtyAndCouple(int N)
        {
            // проверить на пятизначность
            if (N < 10000 || N > 99999)
                return false;


            byte[] fiveNumbers = new byte[5];
            // разобрать по числам
            // например 45791
            fiveNumbers[0] = (byte)(N / 10000);         // 4
            N %= 10000;                                 // 5791
            fiveNumbers[1] = (byte)(N / 1000);          // 5
            N %= 1000;                                  // 791
            fiveNumbers[2] = (byte)(N / 100);           // 7
            N %= 100;                                   // 91
            fiveNumbers[3] = (byte)(N / 10);            // 9
            fiveNumbers[4] = (byte)(N % 10);            // 1

            if (fiveNumbers[0] + fiveNumbers[1] + fiveNumbers[2] + fiveNumbers[3] + fiveNumbers[4] != 30)
                return false;

            byte matches =0;
            // прверяем на парность
            for (byte i = 0; i < 4; i++) // c первой по предпоследнюю
            {
                for (byte k = (byte)(i + 1); k < 5; k++)    // со следующей до посследней
                //for (byte k = i + 1; k < 5; k++)    // со следующей до посследней
                {
                    if (fiveNumbers[i] == fiveNumbers[k])
                    {
                        matches++;
                    }
                }
            }

            if (matches == 1)
                return true;





            return false;
        }

        private static void Thinking()
        {
            for (int i = 0; i < 10; i++)
            {
                Write(".");
                System.Threading.Thread.Sleep(500);
            }
            WriteLine();
        }
    }
}
