int dial = 50;
int zeroCount = 0;

Console.WriteLine("Reading dail input!");

string[] input = File.ReadAllLines("./input.txt");

Console.WriteLine($"Starting dial at {dial}.");

foreach (string c in input)
{
    bool isRight = c.First() == 'R';
    int newVal = -1;

    Console.WriteLine($"Doing input {c}!");

    if (!int.TryParse(c.AsSpan(1), out int value))
    {
        Console.WriteLine($"Unable to parse {c} as valid input!");
        continue;
    }

    if (isRight)
    {
        newVal = (dial + value) % 100;

        Console.WriteLine($"Turned dial from {dial} up to {newVal}.");
        dial = newVal;
    }
    else
    {
        newVal = (dial - value) % 100;

        if(newVal < 0)
        {
            newVal += 100;
        }


        Console.WriteLine($"Turned dial from {dial} down to {newVal}.");
        dial = newVal;
    }

    if (dial == 0)
    {
        zeroCount++;
    }
}

Console.WriteLine($"Amount of zeroes: {zeroCount}.");