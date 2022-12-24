
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

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
    20,
    60,
    100,
    140,
    180,
    220
};

StringBuilder stringBuild = new();

for (int i = 0; i < 240; i++)
{
    if ((i % 40) == 0) stringBuild.AppendLine();

    if (cycleValues.ContainsKey(i) && (cycleValues[i] - 1 <= (i % 40) && (i % 40) <= cycleValues[i] + 1)) // since adding skips two cycles, need to check cycle before to find value
    {
        stringBuild.Append('#');
    }
    else if( cycleValues.ContainsKey(i + 1) && (cycleValues[i + 1] - 1 <= (i % 40) && (i % 40) <= cycleValues[i + 1] + 1))
    {
        stringBuild.Append('#');
    }
    else
    {
        stringBuild.Append('.');
    }

}

Console.WriteLine(stringBuild.ToString());
