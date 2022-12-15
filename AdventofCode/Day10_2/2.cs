
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

int value = 1;
int cycle = 1;

int product = 0;

Dictionary<int, int> cycleValues = new Dictionary<int, int>();

cycleValues.Add(1,1);

foreach (var line in lines)
{
    string[] operation = line.Split(' ');

    value = cycleValues[cycle];

    if (operation[0] == "noop")
    {
        cycle++;
        cycleValues[cycle] = value;
        continue;
    }

    cycle += 2;

    cycleValues[cycle] = value + int.Parse(operation[1]);
}

var breakpoints = new int[]
{
    20,
    60,
    100,
    140,
    180,
    220
};

foreach (KeyValuePair<int, int> pair in cycleValues)
{
    Console.WriteLine(pair.Key);
}

foreach (var breakpoint in breakpoints)
{
    if (cycleValues.ContainsKey(breakpoint))
    {
        Console.WriteLine((breakpoint) * cycleValues[breakpoint]);
        product += (breakpoint) * cycleValues[breakpoint];
    }
    else
    {
        Console.WriteLine((breakpoint) * cycleValues[breakpoint - 1]);
        product += (breakpoint) * cycleValues[breakpoint - 1];
    }
}

Console.WriteLine(product);
