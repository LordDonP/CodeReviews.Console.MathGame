// This program creates a simple Math Game



List<string> history = new List<string>();

bool game = true;

while (game)
    {
        int points = 0;
        int operation = 0;

        while(operation < 1 || operation > 6)
        {
            Console.WriteLine("Choose operator:\n");
            Console.WriteLine("1: Addition");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Multiplication");
            Console.WriteLine("4: Division");
            Console.WriteLine("5: Show game history");
            Console.WriteLine("6: Quit game?");

            string? choice = Console.ReadLine();

            if (Int32.TryParse(choice, out operation))
            {
                if (operation < 1 || operation > 6)
                {
                    Console.WriteLine("\nWrong input, try again!\n");
                    continue;
                }
            }
        }

        int result;

        void decideResult(int result, string calculation)
        {
            Console.WriteLine($"What is the result of {calculation}?");
            string? strInput = Console.ReadLine();
            if (Int32.TryParse(strInput, out int input))
            {
                if (result == input)
                    {
                        Console.WriteLine("Correct!");
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

        while (points < 5)
        {
            int first = new Random().Next(1, 101);
            int second = new Random().Next(1, 101);
            switch (operation)
            {
                case 1:
                    calculation = $"{first} + {second}";
                    result = first + second;
                    decideResult(result, calculation);
                    break;
                case 2:
                    calculation = $"{first} - {second}";
                    result = first - second;
                    decideResult(result, calculation);
                    break;
                case 3:
                    calculation = $"{first} * {second}";
                    result = first * second;
                    decideResult(result, calculation);
                    break;
                case 4:
                    while (!(first % second == 0))
                    {
                        first = new Random().Next(1, 101);
                        second = new Random().Next(1, 101);
                    }
                    calculation = $"{first} / {second}";
                    result = first / second;
                    decideResult(result, calculation);
                    break;
                case 5:
                    if (history.Count != 0)
                    {
                        foreach (string item in history)
                        {
                            Console.WriteLine(item);
                        }
                        points = 6;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nNo game history\n");
                    }
                    break;
                case 6:
                    game = false;
                    return;
                    
            }
        }

    }