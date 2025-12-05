Console.WriteLine("Reading input!");
List<(long min, long max)> ranges = [];
long freshIds = 0;

string[] input = File.ReadAllLines("./input.txt");

foreach (string line in input)
{
    if (line.Contains('-'))
    {
        long[] values = [.. line.Split('-').Select(v => long.Parse(v))];
        ranges.Add((values[0], values[1]));
    }
    else if (string.IsNullOrEmpty(line))
    {
        break;
    }
}

for (int i = ranges.Count - 1; i >= 0; i--)
{
    (long min, long max) = ranges[i];

    for (int j = 0; j < ranges.Count; j++)
    {
        if (i == j)
        {
            continue;
        }

        (long cMin, long cMax) = ranges[j];

        if (min >= cMin && min <= cMax)
        {
            if (max <= cMax)
            {
                ranges.RemoveAt(i);
                break;
            }
            else
            {
                min = cMax + 1;
                ranges[i] = (min, max);
            }
        }
    }
}

foreach (var (min, max) in ranges)
{
    freshIds += max - min + 1;
}

Console.WriteLine($"Amount of fresh IDs: {freshIds}!");