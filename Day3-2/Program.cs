using System.Text;

Console.WriteLine("Reading battery banks!");

string[] input = File.ReadAllLines("./input.txt");
List<long> largestJoltages = [];
int outputLength = 12;

foreach (var line in input)
{
    int[] batteries = [.. line.Select(x => int.Parse(x.ToString()))];
    StringBuilder sb = new();

    int lastIndex = -1;

    while (sb.Length < outputLength)
    {
        int biggest = -1;

        for (int i = lastIndex + 1; i < batteries.Length - (outputLength - 1 - sb.Length); i++)
        {
            int battery = batteries[i];
            if (battery > biggest)
            {
                biggest = battery;
                lastIndex = i;
            }
        }

        sb.Append(biggest);
    }

    long output = long.Parse(sb.ToString());
    largestJoltages.Add(output);

    Console.WriteLine($"Biggest joltage is {output}.");
}

Console.WriteLine($"Total output joltage is {largestJoltages.Sum()}.");