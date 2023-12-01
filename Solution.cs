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

        var result = Solve(input);

        stopwatch.Stop();

        Console.WriteLine($"Result: {result}");
        Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
    }

    protected abstract int Solve(string input);
}