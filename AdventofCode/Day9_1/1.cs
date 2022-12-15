
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

var Visited = new HashSet<(int,int)>();

(int X, int Y) headPosition = new(0, 0);
(int X, int Y) tailPosition = new(0, 0);

Visited.Add(tailPosition);

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
        headPosition.X += movement.X;
        headPosition.Y += movement.Y;

        if (Math.Abs(headPosition.X - tailPosition.X) > 1 ||
            Math.Abs(headPosition.Y - tailPosition.Y) > 1)
        {
            if (headPosition.X != tailPosition.X)
            {
                var xDiff = (headPosition.X - tailPosition.X) / Math.Abs(headPosition.X - tailPosition.X);
                tailPosition.X += xDiff;
            }

            if (headPosition.Y != tailPosition.Y)
            {
                var yDiff = (headPosition.Y - tailPosition.Y) / Math.Abs(headPosition.Y - tailPosition.Y);
                tailPosition.Y += yDiff;
            }

            Visited.Add(tailPosition);
        }

    }
}

Console.WriteLine(Visited.Count);
