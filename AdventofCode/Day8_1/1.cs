
using System.Linq.Expressions;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);
var width = lines[0].Length;
var height = lines.Length;

var grid = new int[width, height];
var visible = new bool[width, height];

for (int x = 0; x < width; x++)
{
    for (int y = 0; y < height; y++)
    {
        grid[x, y] = lines[y][x] - '0';
    }
}

// traverse accross the top and bottom first

Console.WriteLine(grid[0,0]);
for(int x = 0; x < width; x++)
{
    Traverse(0, x, 0);
}

for (int x = 0; x < height; x++)
{
    Traverse(x, 0, 1);
}

var visibilityCounter = 0;
for (int x = 0; x < width; x++)
{
    for (int y = 0; y < height; y++)
    {
        if (visible[x, y])
        {
            visibilityCounter++;
        }
    }
}

Console.WriteLine(visibilityCounter.ToString());

void Traverse(int row, int column, int directionType) // x and y = direction
{
    var maxHeight = grid[row,column];

    visible[row,column] = true;

    (int x, int y) direction = (0, 0);

    // directionType 0 = right, 1 = down

    if(directionType == 0) // rows
    {
        direction = (0, 1);
    }
    else // columns
    {
        direction = (1, 0);
    }

    row += direction.x;
    column += direction.y;

    while (row >= 0 && column >= 0 && row < width && column < height)
    {
        if (grid[row, column] > maxHeight)
        {
            visible[row, column] = true;
            maxHeight = grid[row, column];
            if (maxHeight == 9)
            {
                break;
            }
        }
        else if (row == 0 || column == 0 || row == width - 1 || column == height - 1)
        {
            visible[row, column] = true;
        }

        row += direction.x;
        column += direction.y;
    }
}
// Print the total number of 
