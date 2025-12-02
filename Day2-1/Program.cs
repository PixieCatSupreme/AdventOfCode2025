Console.WriteLine("Reading IDs!");

string[] input = File.ReadAllText("./input.txt").Trim().Split(',');
List<long> invalidIds = [];

foreach (string range in input)
{
    string[] values = range.Split('-');

    if (!long.TryParse(values[0], out long first) || !long.TryParse(values[1], out long second))
    {
        Console.WriteLine($"Invalid input: '{range}'!");
        continue;
    }
    else
    {
        Console.WriteLine($"Checking range '{range}'!");
    }

    for (long i = first; i <= second; i++)
    {
        string s = i.ToString();
        if (s.Length % 2 != 0)
        {
            //Console.WriteLine($"Value '{s}' is valid!");
            continue;
        }

        string f = s[..(s.Length / 2)];
        string l = s[(s.Length / 2)..];

        if (f == l)
        {
            Console.WriteLine($"Invalid ID: '{s}'. Sequence is repeated!");
            invalidIds.Add(i);
        }
    }
}

Console.WriteLine($"Sum of invalid IDs is {invalidIds.Sum()}.");