using System.IO;

int totalScore = 0;

var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

List<string> text = File.ReadAllLines(path).ToList();

using (StreamReader reader = new StreamReader(path))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        var parts = line.Split(" ");
        var opponentShape = (Shape)(parts[0][0] - 'A');
        var outcome = (RoundOutcome)(parts[1][0] - 'X');
        totalScore += CalculateRoundScore(opponentShape, outcome);
    }
}

int CalculateRoundScore(Shape opponent, RoundOutcome outcome)
{
    var roundScore = (int)outcome * 3;
    var shapeScore = 0;
    if (outcome == RoundOutcome.Draw)
    {
        shapeScore = GetShapeScore(opponent);
    }
    else if (outcome == RoundOutcome.Win)
    {
        shapeScore = GetShapeScore((Shape)(((int)opponent + 1) % 3));
    }
    else
    {
        shapeScore = GetShapeScore((Shape)(((int)opponent + 2) % 3));
    }
    return shapeScore + roundScore;
}

Console.WriteLine(totalScore.ToString()); // answer

int GetShapeScore(Shape shape) => (int)shape + 1;

enum Shape
{
    Rock,
    Paper,
    Scissors
}

enum RoundOutcome
{
    Loss,
    Draw,
    Win
}