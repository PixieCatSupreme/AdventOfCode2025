int dial = 50;
int zeroCount = 0;

Console.WriteLine("Reading dail input!");

string[] input = File.ReadAllLines("./input.txt");

Console.WriteLine($"Starting dial at {dial}.");

foreach (string c in input)
{
    bool isRight = c.First() == 'R';
    int newVal = -1;

    if (!int.TryParse(c.AsSpan(1), out int value))
    {
        Console.WriteLine($"Unable to parse {c} as valid input!");
        continue;
    }

    while (value > 100)
    {
        zeroCount++;
        value -= 100;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Dial rolled over zero.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    if (isRight)
    {
        if(dial + value > 100)
        {
            zeroCount++;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Dial rolled over zero.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        newVal = (dial + value) % 100;

        Console.WriteLine($"Turned dial from {dial} up to {newVal} ({c}).");
        dial = newVal;
    }
    else
    {
        bool isZero = dial == 0;
        newVal = (dial - value) % 100;

        if(newVal < 0)
        {
            if(!isZero)
            {
                zeroCount++;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Dial rolled over zero.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            newVal += 100;
        }

        Console.WriteLine($"Turned dial from {dial} down to {newVal} ({c}).");

        dial = newVal;
    }

    if (dial == 0)
    {
        zeroCount++;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Dial is 0.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

Console.WriteLine($"Amount of zeroes: {zeroCount}.");