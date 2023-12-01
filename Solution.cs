using System.Diagnostics;

namespace AdventOfCode;

internal abstract class Solution
{
    abstract public int Year { get; }

    abstract public int Day { get; }

    abstract public string Name { get; }

    public void RunSolution()
    {
        Console.WriteLine(Name);

        var input = File.ReadAllText($"./{Year}/Day{Day}/input.txt");

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var result1 = SolvePart1(input);

        stopwatch.Stop();

        Console.WriteLine($"Result for Part 1: {result1}");
        Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");

        stopwatch.Restart();

        var result2 = SolvePart2(input);

        stopwatch.Stop();

        Console.WriteLine($"Result for Part 2: {result2}");
        Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
    }

    protected abstract int SolvePart1(string input);

    protected abstract int SolvePart2(string input);
}