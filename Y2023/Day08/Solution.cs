using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day8;

internal class Solution : AdventOfCode.Solution
{
    public override int Year => 2023;

    public override int Day => 8;

    public override string Name => "Haunted Wasteland";

    protected override int SolvePart1(string input)
    {
        var mapCount = 0;
        var mapCordinate = "AAA";
        var currentMapping = new string[] { };
        var lines = input.Split(Environment.NewLine);
        var LR = lines[0];
        lines = lines[2..];
        var map = new Dictionary<string, string[]>();

        foreach (var line in lines)
        {
            map.Add(line.Substring(0, 3), line.Substring(line.IndexOf("(")).Replace("(", "").Replace(")", "").Replace(" ", "").Split(","));
        }

        while (mapCordinate != "ZZZ")
        {
            mapCount++;
            currentMapping = map[mapCordinate];
            if (LR.Length < mapCount)
            {
                LR += LR;
            }
            if (LR[mapCount - 1] == 'L')
            {
                mapCordinate = currentMapping[0];
            }
            else
            {
                mapCordinate = currentMapping[1];
            }
        }

        return mapCount;
    }

    protected override int SolvePart2(string input)
    {
        var currentCoordinates = "";
        var currentMappings = new List<string> { };
        var lines = input.Split(Environment.NewLine);
        var LR = lines[0];
        lines = lines[2..];
        var map = new Dictionary<string, string[]>();

        foreach (var line in lines)
        {
            if(line.Contains("A ="))
            {
                currentMappings.Add(line.Substring(0, 3));
            }
            map.Add(line.Substring(0, 3), line.Substring(line.IndexOf("(")).Replace("(", "").Replace(")", "").Replace(" ", "").Split(","));
        }
        var mapCount = new List<int>();

        foreach (var currentMapping in currentMappings)
        {
            currentCoordinates = currentMapping;
            var i = 0;
            while (currentCoordinates[currentCoordinates.Length-1] != 'Z')
            {
                i++;
                if (LR.Length < i)
                {
                    LR += LR;
                }
                if (LR[i - 1] == 'L')
                {
                    currentCoordinates = map[currentCoordinates][0];
                }
                else
                {
                    currentCoordinates = map[currentCoordinates][1];
                }
            }
            mapCount.Add(i);
        }
        int lcd = FindLeastCommonDenominator(mapCount);

        return lcd;
    }

    static int FindLeastCommonDenominator(List<int> numbers)
    {
        int lcm = 1;

        foreach (int number in numbers)
        {
            lcm = CalculateLCM(lcm, number);
        }

        return lcm;
    }

    static int CalculateLCM(int a, int b)
    {
        // Calculate the greatest common divisor (GCD) using Euclidean algorithm
        int gcd = CalculateGCD(a, b);

        // Calculate the LCM using the formula: LCM(a, b) = |a * b| / GCD(a, b)
        int lcm = Math.Abs(a * b) / gcd;

        return lcm;
    }

    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}
