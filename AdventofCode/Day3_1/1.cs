using System.IO;
using System.IO.Pipes;

int totalScore = 0;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

List<string> text = File.ReadAllLines(path).ToList();
int total = 0;
using (StreamReader reader = new StreamReader(path))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        string firstCompartment = line.Substring(0, line.Length / 2);
        string secondCompartment = line.Substring(line.Length / 2 );
        List<char> common = new List<char>();

        common = FindCommonChars(firstCompartment, secondCompartment).ToList();

        total += totalValue(common);
    }

    Console.WriteLine(total);
    Console.ReadLine();

    HashSet<char> FindCommonChars(string firstCompartment, string secondCompartment){
        // can assume firstcompartment == secondcompartment
        HashSet<char> firstCompartmentSet = new HashSet<char>();
        HashSet<char> secondCompartmentSet = new HashSet<char>();

        string matching = "";

        for (int i = 0; i<firstCompartment.Length; i++)
        {
            firstCompartmentSet.Add(firstCompartment[i]);
            secondCompartmentSet.Add(secondCompartment[i]);
        }

        HashSet<char> answer = new HashSet<char>(firstCompartmentSet);

        answer.IntersectWith(secondCompartmentSet);

        return answer;

    }

    int totalValue(List<char> list)
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