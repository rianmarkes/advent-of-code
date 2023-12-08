using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day3;

internal class Solution : AdventOfCode.Solution
{
    public override int Year => 2023;

    public override int Day => 3;

    public override string Name => "Gear Ratios";

    protected override int SolvePart1(string input)
    {
        var finalSum = 0;
        var lines = new List<string>(input.Split('\n'));

        for(int i = 1; i < lines.Count; i++)
        {
            if(i == 1)
            {
                var currentLine = lines[i - 1];
                var nextLine = lines[i];
                Console.WriteLine(currentLine);
                Console.WriteLine(nextLine);
            } 
            else
            {
                var previousLine = lines[i-2];
                var currentLine = lines[i-1];
                var nextLine = lines[i];
                Console.WriteLine(previousLine);
                Console.WriteLine(currentLine);
                Console.WriteLine(nextLine);
            }
        }
        
        return finalSum;
    }

    protected override int SolvePart2(string input)
    {
        return 0;
    }
}
