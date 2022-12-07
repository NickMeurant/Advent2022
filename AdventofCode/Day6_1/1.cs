using System.Linq;
using System.Net;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

string line = lines[0];
int left = 0;
int right = 1;

HashSet<char> found = new HashSet<char>();

while (right < line.Length - 1)
{
    if (right - left < 3)
    {
        found.Add(line[right]);
        found.Add(line[left]);
        right++;
        continue;
    }

    found.Remove(line[left]);
    left++;

    right++;
    found.Add(line[right]);

    if (found.Count == 4)
    {
        Console.WriteLine(right - 1);
        break;
    }
}