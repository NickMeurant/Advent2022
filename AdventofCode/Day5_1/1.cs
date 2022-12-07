using System.Net;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

foreach (string line in lines)
{
    Console.WriteLine(line);
}
Console.ReadLine();


