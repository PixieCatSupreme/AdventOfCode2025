Console.WriteLine("Reading battery banks!");

string[] input = File.ReadAllLines("./input.txt");
List<long> largestJoltages = [];

foreach (var line in input)
{
    int[] batteries = [.. line.Select(x => int.Parse(x.ToString()))];
    int firstBiggest = -1;
    int secondBiggest = -1;

    int firstBiggestIndex = -1;

    for (int i = 0; i < batteries.Length - 1; i++)
    {
        int battery = batteries[i];
        if (battery > firstBiggest)
        {
            firstBiggest = battery;
            firstBiggestIndex = i;
        }
    }

    for (int i = firstBiggestIndex + 1; i < batteries.Length; i++)
    {
        int battery = batteries[i];
        if (battery > secondBiggest)
        {
            secondBiggest = battery;
        }
    }

    long output = long.Parse($"{firstBiggest}{secondBiggest}");
    largestJoltages.Add(output);

    Console.WriteLine($"Biggest joltage is {output}.");
}

Console.WriteLine($"Total output joltage is {largestJoltages.Sum()}.");