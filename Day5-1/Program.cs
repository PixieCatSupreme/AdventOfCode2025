Console.WriteLine("Reading input!");
List<(long min, long max)> ranges = [];
List<long> ids = [];
int freshIds = 0;

string[] input = File.ReadAllLines("./input.txt");

foreach (string line in input)
{
    if (line.Contains('-'))
    {
        long[] values = [.. line.Split('-').Select(v => long.Parse(v))];
        ranges.Add((values[0], values[1]));
    }
    else if (long.TryParse(line, out long id))
    {
        ids.Add(id);
    }
}

foreach (long id in ids)
{
    if (IsInRange(id))
    {
        freshIds++;
    }
}

Console.WriteLine($"Amount of fresh IDs: {freshIds}!");

bool IsInRange(long id)
{
    foreach (var (min, max) in ranges)
    {
        if (id >= min && id <= max)
        {
            return true;
        }
    }

    return false;
}