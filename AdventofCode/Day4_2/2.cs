using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Pipes;
using System.Net;
var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

List<string> text = File.ReadAllLines(path).ToList();
int same = 0;

using (StreamReader reader = new StreamReader(path))
{
    string line;

    while ((line = reader.ReadLine()) != null) // get groups of 6 elves and find common between first three and last three
    {
        string firstElf = line.Split(",")[0];
        string secondElf = line.Split(",")[1];

        int elf1 = int.Parse(firstElf.Split("-")[0]);
        int elf2 = int.Parse(firstElf.Split("-")[1]);

        List<int> elf1Land = CreateList(int.Parse(firstElf.Split("-")[0]), int.Parse(firstElf.Split("-")[1]));
        List<int> elf2Land = CreateList(int.Parse(secondElf.Split("-")[0]), int.Parse(secondElf.Split("-")[1]));

        if (elf1Land.Any(i => elf2Land.Contains(i)) || elf2Land.Any(i => elf1Land.Contains(i))) // check if subset
        {
            same++;
        }
    }
}
Console.WriteLine(same);
Console.ReadLine();

List<int> CreateList(int start, int end) // create a list representation of the land
{
    List<int> numberList = new List<int>();
    for (int i = start; i < end + 1; i++)
    {
        numberList.Add(i);
    }
    return numberList;
}