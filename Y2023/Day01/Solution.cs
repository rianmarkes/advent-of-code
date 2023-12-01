using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day1;

internal class Solution : AdventOfCode.Solution
{
    public override int Year => 2023;

    public override int Day => 1;

    public override string Name => "Trebuchet?!";

    protected override int SolvePart1(string input)
    {
        var sum = 0;
        var lines = input.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            sum = AddTogether(sum, line);
        }

        return sum;
    }

    protected override int SolvePart2(string input)
    {
        var sum = 0;
        var lines = input.Split(Environment.NewLine);
        var pattern = "(zero|one|two|three|four|five|six|seven|eight|nine)";

        foreach (var line in lines)
        {
            var result1 = Regex.Replace(line, pattern, match => ConvertSpelledOutToNumber(match.Value));
            var result2 = Regex.Replace(line, pattern, match => ConvertSpelledOutToNumber(match.Value), RegexOptions.RightToLeft);
            var result = result1 + result2;

            sum = AddTogether(sum, result);
        }

        return sum;
    }

    private int AddTogether(int sum, string line)
    {
        var nums = Regex.Replace(line, "[^0-9]", ""); //remove all non-numeric characters
        if (nums.Length > 0)
        {
            sum += int.Parse(nums[0] + nums[nums.Length - 1].ToString());
        }

        return sum;
    }

    private string ConvertSpelledOutToNumber(string spelledOut)
    {
        var spelledOutDigits = new List<string>() { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        return spelledOutDigits.IndexOf(spelledOut).ToString();
    }
}
