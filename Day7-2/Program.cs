using System.Text;

Console.WriteLine("Reading map input!");

Map map =  new(File.ReadAllLines("./input.txt"));

Console.WriteLine($"Timeline count is: {map.Total(map.GetStartPosition())}!");

class Map(string[] input)
{
    private readonly string[] map = input;

    private readonly long[,] memoization = new long[input[0].Length, input.Length+1];

    public Position GetStartPosition()
    {
        return new(map[0].IndexOf('S'), 0);
    }

    public long Total(Position pos)
    {
        if (memoization[pos.X, pos.Y] != 0)
        {
            return memoization[pos.X, pos.Y];
        }

        long result;

        if (pos.Y >= map.Length)
        {
            result = 1;
        } 
        else if (IsSplitter(pos))
        {
            result = Total(pos with { X = pos.X - 1 }) + Total(pos with { X = pos.X + 1 });
        }
        else
        {
            result = Total(pos with { Y = pos.Y + 1 });
        }

        memoization[pos.X, pos.Y] = result;

        return result;
    }

    private bool IsSplitter(Position pos)
    {
        return map[pos.Y][pos.X] == '^';
    }
}

struct Position(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}