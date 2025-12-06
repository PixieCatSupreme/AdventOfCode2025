using static Problem;

Console.WriteLine("Reading input!");

List<Problem> problems = ReadInput("./input.txt");
long[] answers = [.. problems.Select(p => p.Solve())];

Console.WriteLine($"Sum of all answers is: {answers.Sum()}!");

static List<Problem> ReadInput(string path)
{
    string[] input = File.ReadAllLines(path);
    string lastLine = input.Last();

    List<Problem> output = [];
    List<(ProblemType type, int length)> parts = ParseProblem(lastLine);
    parts.Reverse();

    int index = lastLine.Length-1;

    foreach (var part in parts)
    {
        List<long> numbers = [];
        for (int i = 0; i < part.length; i++)
        {
            string val = "";

            for (int j = 0; j < input.Length -1; j++)
            {
                val += input[j][index -i];
            }

            numbers.Add(long.Parse(val.Trim()));
        }

        index -= part.length +1;

        output.Add(new(numbers, part.type));
    }


    return output;
}

static List<(ProblemType type, int length)> ParseProblem(string input)
{
    List<(ProblemType type, int length)> output = [];
    string[] parts = input.Split(' ');

    foreach (string part in parts)
    {
        if (part == "")
        {
            (ProblemType type, int length) = output[^1];
            output[^1] = (type, length + 1);
        }
        else
        {
            if (part == "+")
            {
                output.Add((ProblemType.Addition, 1));
            }
            else if (part == "*")
            {
                output.Add((ProblemType.Multiplication, 1));
            }
        }
    }

    return output;
}

static string FixSpaces(string input)
{
    input = input.Trim();

    while (input.Contains("  "))
    {
        input = input.Replace("  ", " ");
    }

    return input;
}

struct Problem(List<long> numbers, ProblemType type)
{
    public enum ProblemType
    {
        Addition,
        Multiplication
    }

    public readonly List<long> Numbers => numbers;
    public readonly ProblemType Type => type;

    public long Solve()
    {
        switch (type)
        {
            case ProblemType.Addition:
                return numbers.Sum();
            case ProblemType.Multiplication:
                long answer = numbers.First();

                for (int i = 1; i < numbers.Count; i++)
                {
                    answer *= numbers[i];
                }
                return answer;
            default:
                throw new NotImplementedException();
        }
    }
}