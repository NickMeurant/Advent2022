using System.IO;

long totalScore = 0;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

List<string> text = File.ReadAllLines(path).ToList();

using (StreamReader reader = new StreamReader(path))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        var parts = line.Split(" ");
        var opponentShape = (Shape)(parts[0][0] - 'A');
        var ourShape = (Shape)(parts[1][0] - 'X');
        totalScore += CalculateRoundScore(opponentShape, ourShape);
    }
}

long CalculateRoundScore(Shape opponent, Shape we)
{
    var shapeScore = GetShapeScore(we);
    var roundScore = 3;
    if (opponent != we)
    {
        int ourShapeIndex = (int)we;
        int opponentShapeIndex = (int)opponent;
        roundScore = ourShapeIndex == (opponentShapeIndex + 1) % 3 ? 6 : 0;
    }

    return shapeScore + roundScore;
}

Console.WriteLine(totalScore.ToString()); // answer

long GetShapeScore(Shape shape) => (int)shape + 1;

enum Shape
{
    Rock,
    Paper,
    Scissors
}