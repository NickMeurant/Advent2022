
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

HashSet<string> Visited = new HashSet<string>();

List<Dictionary<string,int>> rope = new List<Dictionary<string, int>>();

for (int i = 0; i < 10; i++)
{
    Dictionary<string, int> value = new Dictionary<string, int>() { { "X", 0 }, { "Y", 0 } };
    rope.Add(value);
}

Dictionary<string, int> startingPosition = new Dictionary<string, int> { { "X", 0 }, { "Y", 0 } };
Visited.Add("X" + startingPosition["X"].ToString() + "Y" + startingPosition["Y"].ToString());

for (int i = 0; i < lines.Length; i++)
{
    string direction = lines[i].Split(" ")[0];

    int counter = int.Parse(lines[i].Split(" ")[1]);

    (int X, int Y) movement = direction switch
    {
        "U" => (0, 1),
        "D" => (0, -1),
        "R" => (1, 0),
        "L" => (-1, 0),
        _ => throw new NotImplementedException()
    };

    for (int j = 0; j < counter; j++)
    {
        rope[0]["X"] += movement.X;
        rope[0]["Y"] += movement.Y;

        for (int k = 1; k < 10; k++)
        {
            var headPosition = rope[k - 1];
            var tailPosition = rope[k];

            if (Math.Abs(headPosition["X"] - tailPosition["X"]) > 1 ||
            Math.Abs(headPosition["Y"] - tailPosition["Y"]) > 1)
            {
                if (headPosition["X"] != tailPosition["X"])
                {
                    var xDiff = (headPosition["X"] - tailPosition["X"]) / Math.Abs(headPosition["X"] - tailPosition["X"]);
                    tailPosition["X"] += xDiff;
                }

                if (headPosition["Y"] != tailPosition["Y"])
                {
                    var yDiff = (headPosition["Y"] - tailPosition["Y"]) / Math.Abs(headPosition["Y"] - tailPosition["Y"]);
                    tailPosition["Y"] += yDiff;
                }

                rope[k] = tailPosition;

                if (k == 9)
                {
                    string value = "X" + tailPosition["X"].ToString() + "Y" + tailPosition["Y"].ToString();
                    Visited.Add(value);
                }
            }
        }
    }
}

Console.WriteLine(Visited.Count);
