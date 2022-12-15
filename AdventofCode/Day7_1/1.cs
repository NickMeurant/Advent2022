using System.Linq;
using System.Net;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

string line = lines[0];
int left = 0;

int NEEDEDLENGTH = 14;


