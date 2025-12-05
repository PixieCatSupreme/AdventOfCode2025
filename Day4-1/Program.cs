Console.WriteLine("Reading map!");
bool[,] map = ReadMap("./input.txt");
int maxAdjacents = 4;

int w = map.GetLength(1);
int h = map.GetLength(0);

List<(int x, int y)> validRolls = [];

for (int y = 0; y < h; y++)
{
    for (int x = 0; x < w; x++)
    {
        if (map[y, x] && IsValidRoll(x, y))
        {
            validRolls.Add((x, y));
        }
    }
}

Console.WriteLine($"Valid roll count: {validRolls.Count}!");

static bool[,] ReadMap(string path)
{
    string[] input = File.ReadAllLines(path);
    int w = input[0].Length;
    int h = input.Length;

    bool[,] output = new bool[w, h];

    for (int y = 0; y < h; y++)
    {
        for (int x = 0; x < w; x++)
        {
            output[y, x] = input[y][x] == '@';
        }
    }

    return output;
}

bool IsValidRoll(int x, int y)
{
    int adjacents = 0;
    int h = map.GetLength(0);
    int w = map.GetLength(1);

    for (int i = -1; i < 2; i++)
    {
        for (int j = -1; j < 2; j++)
        {
            int cy = y + i;
            int cx = x + j;

            if ((i == 0 && j == 0) || 
                cy < 0 || cx < 0 ||
                cy >= h || cx >= w)
            {
                continue;
            }

            if (map[y + i, x + j])
            {
                adjacents++;
                if (adjacents == maxAdjacents)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    return true;
}