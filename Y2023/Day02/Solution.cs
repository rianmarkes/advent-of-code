using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day2;

internal class Solution : AdventOfCode.Solution
{
    public override int Year => 2023;

    public override int Day => 2;

    public override string Name => "Cube Conundrum";

    protected override int SolvePart1(string input)
    {
        var idSum = 0;
        var availableCubes = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 },
        };
        var lines = input.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            var gameNumber = int.Parse(line.Split(":")[0].Split(" ")[1]);
            idSum += TryColors(availableCubes, line, gameNumber);
        }

        return idSum;
    }

    private static int TryColors(Dictionary<string, int> availableCubes, string line, int gameNumber)
    {
        var pulls = line.Split(":")[1].Split(";");
        foreach (var pull in pulls)
        {
            var colors = pull.Split(",");
            foreach (var color in colors)
            {
                var colorName = color.Split(" ")[2];
                var colorCount = int.Parse(color.Split(" ")[1]);
                if (availableCubes[colorName] < colorCount)
                {
                    return 0;
                }
            }
        }
        return gameNumber;
    }

    protected override int SolvePart2(string input)
    {
        var powerSum = 0;
        var pattern = "(\\d+ [a-zA-z]+)";
        var lines = input.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            var redCount = new List<int>();
            var blueCount = new List<int>();
            var greenCount = new List<int>();
            var colors = Regex.Matches(line, pattern);
            foreach (var color in colors)
            {
                var colorString = color.ToString();
                if (colorString.Contains("red"))
                {
                    redCount.Add(int.Parse(colorString.Split(" ")[0]));
                }
                else if (colorString.Contains("blue"))
                {
                    blueCount.Add(int.Parse(colorString.Split(" ")[0]));
                }
                else if (colorString.Contains("green"))
                {
                    greenCount.Add(int.Parse(colorString.Split(" ")[0]));
                }   
            }
            powerSum += redCount.Max() * blueCount.Max() * greenCount.Max();
        }

        return powerSum;
    }
}
