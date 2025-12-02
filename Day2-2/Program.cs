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
        int l = s.Length;

        for (int j = 1; j <= l / 2; j++)
        {
            if (l % j != 0)
            {
                continue;
            }

            string check = s[..j];
            bool invalid = true;

            for (int k = 1; k < l / j; k++)
            {
                if (s.Substring(k * j, j) != check)
                {
                    invalid = false;
                    break;
                }
            }

            if (invalid) 
            {
                invalidIds.Add(i);
                break;
            }
        }
    }

}

Console.WriteLine($"Sum of invalid IDs is {invalidIds.Sum()}.");