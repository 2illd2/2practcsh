
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите программу:");
            Console.WriteLine("1. Игра 'Угадай число'");
            Console.WriteLine("2. Таблица умножения");
            Console.WriteLine("3. Вывод делителей числа");
            Console.WriteLine("4. Выйти из программы");

            Console.Write("Введите номер программы: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    RunGuessNumberGame();
                    break;
                case 2:
                    RunMultiplicationTable();
                    break;
                case 3:
                    RunDivisorsProgram();
                    break;
                case 4:
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void RunGuessNumberGame()
    {
        Console.Clear();
        Console.WriteLine("Игра 'Угадай число':");
        GuessNumberGame.Run();
    }

    static void RunMultiplicationTable()
    {
        Console.Clear();
        Console.WriteLine("Таблица умножения:");
        MultiplicationTable.Run();
    }

    static void RunDivisorsProgram()
    {
        Console.Clear();
        Console.WriteLine("Вывод делителей числа:");
        Divisors.Run();
    }
}

class GuessNumberGame
{
    public static void Run()
    {
        Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");

        Random random = new Random();
        int targetNumber = random.Next(0, 101);
        int userGuess;

        do
        {
            Console.Write("Введите вашу догадку (от 0 до 100): ");
            if (!int.TryParse(Console.ReadLine(), out userGuess))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                continue;
            }

            if (userGuess < targetNumber)
                Console.WriteLine("Больше!");
            else if (userGuess > targetNumber)
                Console.WriteLine("Меньше!");
            else
                Console.WriteLine("Поздравляю, вы угадали!");

        } while (userGuess != targetNumber);

        Console.WriteLine("Возвращаемся в меню выбора программы.");
    }
}

class MultiplicationTable
{
    public static void Run()
    {
        Console.WriteLine("Таблица умножения:");

        int[,] multiplicationTable = new int[10, 10];

        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                multiplicationTable[i - 1, j - 1] = i * j;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write($"{multiplicationTable[i, j],3} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Возвращаемся в меню выбора программы.");
    }
}

class Divisors
{
    public static void Run()
    {
        Console.WriteLine("Программа для вывода делителей числа.");

        do
        {
            Console.Write("Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                continue;
            }

            Console.Write($"Делители числа {number}: ");
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    Console.Write(i + " ");
            }

            Console.WriteLine("\nЖелаете ввести еще одно число? (y/n): ");
        } while (Console.ReadLine().ToLower() == "y");

        Console.WriteLine("Возвращаемся в меню выбора программы.");
    }
}