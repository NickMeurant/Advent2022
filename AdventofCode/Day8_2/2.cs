
using System.Data;
using System.Linq.Expressions;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);
var width = lines[0].Length;
var height = lines.Length;

var grid = new int[width, height];

for (int x = 0; x < width; x++)
{
    for (int y = 0; y < height; y++)
    {
        grid[x, y] = lines[x][y] - '0';
    }
}

// traverse accross the top and bottom first
int maxView = 0;

int[,] directions = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

for (int x = 1; x < width -1; x++)
{
    for (int y = 1; y < height -1; y++)
    {
        maxView = Math.Max(maxView, Traverse(x, y));
    }
}

Console.WriteLine(maxView);

int Traverse(int row, int column) // x and y = direction
{
    var treeHeight = grid[row,column];

    int total = 1;
    for(int i = 0; i<directions.GetLength(0); i++)
    {
        int currentRow = row + directions[i,0];
        int currentColumn = column + directions[i,1];
        int distance = 0;
        while (currentRow >= 0 && currentColumn >= 0 && currentRow < width && currentColumn < height)
        {
            distance++;
            if (grid[currentRow, currentColumn] >= treeHeight)
            {
                break;
            }
            currentRow += directions[i,0];
            currentColumn += directions[i,1];
        }
        total *= distance;
    }
    return total;
}
// Print the total number of 
