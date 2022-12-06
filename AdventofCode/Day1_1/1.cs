var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
List<string> text = File.ReadAllLines(path).ToList();

List<long> elveCalories = new List<long>();

long current = 0;
long most = 0;

using (StreamReader reader = new StreamReader(path))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            elveCalories.Add(current);
            current = 0;
        }
        else
        {
            current += long.Parse(line);
        }
    }
}

Console.WriteLine(elveCalories.MaxBy(x => x));