using System.IO;
using System.IO.Pipes;
using System.Net;

int totalScore = 0;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

List<string> text = File.ReadAllLines(path).ToList();
int total = 0;
List<List<string>> elfGroups = new List<List<string>>();
using (StreamReader reader = new StreamReader(path))
{
    string line;
    int count = 0;

    List<string> elfGroup = new List<string>();

    while ((line = reader.ReadLine()) != null) // get groups of 6 elves and find common between first three and last three
    {
        elfGroup.Add(line);

        if (count == 5)
        {
            elfGroups.Add(elfGroup);
            elfGroup = new List<string>();
        }
        count = (count + 1) % 6;
    }
    //Console.ReadLine();

    foreach (List<string> a in elfGroups)
    {
        string group1 = FindCommonChars(a.Take(3).ToList());
        string group2 = FindCommonChars(a.Skip(3).Take(3).ToList());

        totalScore += totalValue(group1);
        totalScore += totalValue(group2);
    }
    Console.WriteLine(totalScore);
    Console.ReadLine();


    string FindCommonChars(List<string> elfGroup){
        // can assume firstcompartment == secondcompartment
        HashSet<char> firstelf = new HashSet<char>(elfGroup[0]);
        HashSet<char> secondelf = new HashSet<char>(elfGroup[1]);
        HashSet<char> thirdelf = new HashSet<char>(elfGroup[2]);

        HashSet<char> intersect = new HashSet<char>(firstelf);

        intersect.IntersectWith(secondelf);
        intersect.IntersectWith(thirdelf);

        List<char> answer = intersect.ToList();

        return new string(answer.ToArray());
    }

    int totalValue(string list)
    {
        int total = 0;

        foreach (char c in list)
        {
            if (Char.IsLower(c))
            {
                total += (int)c - 96;
            }
            else
            {
                total += (int)c - 38;
            }
        }

        return total;
    }
}