using System.Text;

Console.WriteLine("Reading map input!");

string[] input = File.ReadAllLines("./input.txt");
int splits = 0;

input[0] = input[0].Replace('S', '|');

for (int i = 1; i < input.Length; i++)
{
    StringBuilder sb = new(input[i]);
    string prev = input[i - 1];

    for (int j = 0; j < sb.Length; j++)
    {
        if (prev[j] != '|')
        {
            continue;
        }

        if (sb[j] == '^')
        {
            if (j - 1 >= 0)
            {
                sb[j - 1] = '|';
            }
            if (j + 1 < sb.Length)
            {
                sb[j + 1] = '|';
            }

            splits++;
        }
        else 
        {
            sb[j] = '|';
        }
    }

    input[i] = sb.ToString();
}

Console.WriteLine($"Split count is: {splits}!");