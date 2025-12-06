using static Problem;

Console.WriteLine("Reading input!");

List<Problem> problems = ReadInput("./input.txt");
long[] answers = [.. problems.Select(p => p.Solve())];

Console.WriteLine($"Sum of all answers is: {answers.Sum()}!");

static List<Problem> ReadInput(string path)
{
    string[][] input = [.. File.ReadAllLines(path).Select(l => FixSpaces(l).Split(' '))];
    List<Problem> output = [];

    for (int i = 0; i < input[0].Length; i++)
    {
        List<long> numbers = [];

        for (int j = 0; j < input.Length; j++)
        {
            if (long.TryParse(input[j][i].ToString(), out long num))
            {
                numbers.Add(num);
            }
            else
            {
                ProblemType pType = input[j][i] switch
                {
                    "+" => ProblemType.Addition,
                    "*" => ProblemType.Multiplication,
                    _ => throw new NotImplementedException()
                };

                output.Add(new Problem(numbers, pType));
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