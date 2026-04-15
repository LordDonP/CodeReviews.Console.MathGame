using System.Drawing;
using System.Runtime.InteropServices;

List<string> history = new List<string>();

bool game = true;

int difficulty = 0;

int limit = 0;

while (difficulty < 1 || difficulty > 3)
{
    Console.WriteLine("Choose difficulty:\n");
    Console.WriteLine("1: Easy");
    Console.WriteLine("2: Normal");
    Console.WriteLine("3: Hard");

    string? stringDifficulty = Console.ReadLine();

    if (Int32.TryParse(stringDifficulty, out difficulty))
    {
        if (difficulty < 1 || difficulty > 3)
        {
            Console.WriteLine("\nWrong input, try again!\n");
            continue;
        }
        else
        {
            switch (difficulty)
            {
                case 1:
                    limit = 10;
                    break;
                case 2:
                    limit = 100;
                    break;
                case 3:
                    limit = 1000;
                    break;
            }
        }
    }
}



while (game)
{
    int points = 0;
    int operation = 0;

    Random random = new Random();

    while (operation < 1 || operation > 7)
    {
        Console.WriteLine("Choose operator:\n");
        Console.WriteLine("1: Addition");
        Console.WriteLine("2: Subtraction");
        Console.WriteLine("3: Multiplication");
        Console.WriteLine("4: Division");
        Console.WriteLine("5: Random");
        Console.WriteLine("6: Show game history");
        Console.WriteLine("7: Quit game?");

        string? choice = Console.ReadLine();

        if (Int32.TryParse(choice, out operation))
        {
            if (operation < 1 || operation > 7)
            {
                Console.WriteLine("\nWrong input, try again!\n");
                continue;
            }
        }
    }

    int result;

    void DecideResult(int result, string calculation)
    {
        Console.WriteLine($"What is the result of {calculation}?");
        string? strInput = Console.ReadLine();
        if (Int32.TryParse(strInput, out int input))
        {
            if (result == input)
            {
                points++;
                history.Add($"{calculation} = {input}");
            }
            else
            {
                Console.WriteLine("Wrong, try again");
            }
        }

    }

    string calculation = "";

    bool exitCondition = false;

    bool randomOperation = false;

    var startTime = DateTime.Now;

    while (points < 5 && !exitCondition)
    {

        if (operation == 5 || randomOperation == true)
        {
            operation = random.Next(1, 5);
            randomOperation = true;
        }

        int first = random.Next(1, limit);
        int second = random.Next(1, limit);
        switch (operation)
        {
            case 1:
                calculation = $"{first} + {second}";
                result = first + second;
                DecideResult(result, calculation);
                break;
            case 2:
                calculation = $"{first} - {second}";
                result = first - second;
                DecideResult(result, calculation);
                break;
            case 3:
                calculation = $"{first} * {second}";
                result = first * second;
                DecideResult(result, calculation);
                break;
            case 4:
                while (!(first % second == 0))
                {
                    first = random.Next(1, limit);
                    second = random.Next(1, limit);
                }
                calculation = $"{first} / {second}";
                result = first / second;
                DecideResult(result, calculation);
                break;
            case 6:
                if (history.Count != 0)
                {
                    foreach (string item in history)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    exitCondition = true;
                    break;
                }
                else
                {
                    Console.WriteLine("\nNo game history\n");
                    exitCondition = true;
                    break;
                }
            case 7:
                game = false;
                return;
        }

        if (points == 5)
        {
            var endTime = DateTime.Now;
            var timeSpan = endTime - startTime;
            Console.WriteLine($"Game lenght: {timeSpan}");
        }
    }
}