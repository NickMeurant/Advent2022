using System.Net;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

var lines = File.ReadAllLines(path);

var blankLine = Array.IndexOf(lines, string.Empty); // diagram ends when all blank lines

var numberOfStacks = int.Parse(lines[blankLine - 1]
    .Trim()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Last());

var stacks = new Stack<char>[numberOfStacks];

// get stack info from diagram

for(int line = blankLine - 2; line >= 0; line--)
{
    string crateLine = lines[line];
    Console.WriteLine(crateLine);

    for(int i = 0; i < numberOfStacks; i++)
    {
        char crate = crateLine[i*4 + 1];
        if (Char.IsLetter(crate))
        {
            stacks[i] ??= new Stack<char>();
            stacks[i].Push(crate);
        }
    }
}

// read instructions, instructions start on blankLine + 1 (10)

for (int lineNumber = blankLine + 1; lineNumber < lines.Length; lineNumber++)
{
    string commands = lines[lineNumber];

    Console.WriteLine(commands);

    int amount = int.Parse(commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

    int fromStack = int.Parse(commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3]) -1;

    int toStack = int.Parse(commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)[5]) -1;

    for (int i = 0; i< amount; i++)
    {
        char crate = stacks[fromStack].Pop();
        stacks[toStack].Push(crate);
    }
}

for(int i = 0;i<stacks.Length; i++)
{
    Console.Write(stacks[i].Peek().ToString());
}




