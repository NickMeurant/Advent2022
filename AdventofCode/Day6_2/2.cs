using System.Linq;
using System.Net;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

string line = lines[0];
int left = 0;

int NEEDEDLENGTH = 14;

while (left + NEEDEDLENGTH < line.Length - 1)
{
    string currentSubString = line.Substring(left, NEEDEDLENGTH);

    if (new HashSet<char>(currentSubString.ToCharArray()).Count == NEEDEDLENGTH)
    {
        Console.WriteLine(left + NEEDEDLENGTH);
        return;
    }
    else
    {
        left++;
    }
}
