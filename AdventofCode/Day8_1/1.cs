using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

string[] lines = File.ReadAllLines(path);

List<List<int>> gridLine = new List<List<int>>();

for(int i = 0;i< lines.Length; i++) // convert to 2d list
{
    List<int> intRow = lines[i].Select(digit => int.Parse(digit.ToString())).ToList();
    gridLine.Add(intRow);
}

int[][] grid = gridLine.Select(a => a.ToArray()).ToArray();

//for (int i = 0;i < grid.Length; i++)
//{
//    for(int j = 0; i < grid[0].Length; j++)
//    {
//        Console.WriteLine(grid[i][j].ToString());
//    }
//    Console.WriteLine("");
//}

int visibleTrees = 0;

// Iterate over each row of the grid
for (int row = 0; row < grid.GetLength(0); row++)
{
    // Find the tallest tree in the row
    int tallest = 0;
    for (int col = 0; col < grid.GetLength(1); col++)
    {
        if (grid[row][col] > tallest)
        {
            tallest = grid[row][col];
        }
    }

    // Check if the tallest tree is visible from outside the grid
    bool visible = true;
    for (int col = 0; col < grid.GetLength(1); col++)
    {
        if (grid[row][col] > 0 && grid[row][col] < tallest)
        {
            visible = false;
            break;
        }
    }

    // If the tallest tree is visible, increment the count
    if (visible)
    {
        visibleTrees++;
    }
}

// Iterate over each column of the grid
for (int col = 0; col < grid.GetLength(1); col++)
{
    // Find the tallest tree in the column
    int tallest = 0;
    for (int row = 0; row < grid.GetLength(0); row++)
    {
        if (grid[row][col] > tallest)
        {
            tallest = grid[row][col];
        }
    }

    // Check if the tallest tree is visible from outside the grid
    bool visible = true;
    for (int row = 0; row < grid.GetLength(0); row++)
    {
        if (grid[row][col] > 0 && grid[row][col] < tallest)
        {
            visible = false;
            break;
        }
    }

    // If the tallest tree is visible, increment the count
    if (visible)
    {
        visibleTrees++;
    }
}

// Print the total number of visible trees
Console.WriteLine(visibleTrees);
