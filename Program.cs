using AdventOfCode;
using System.Reflection;

var usage = @"
Usage: dotnet run [year] [day]

year: The year of the puzzle to solve. Defaults to the current year.
day: The day of the puzzle to solve. Defaults to the current day.
";

var solutions = Assembly
  .GetEntryAssembly()!
  .GetTypes()
  .Where(t => t.IsClass && !t.IsAbstract && typeof(Solution).IsAssignableFrom(t))
  .Select(t => (Solution)Activator.CreateInstance(t)!);


var year = int.TryParse(Environment.GetCommandLineArgs().ElementAtOrDefault(1), out var parsedYear) ?
    parsedYear :
    DateTime.Now.Year;

var day = int.TryParse(Environment.GetCommandLineArgs().ElementAtOrDefault(2), out var parsedDay) ?
    parsedDay :
    DateTime.Now.Day;

var solution = solutions.FirstOrDefault(s => s.Year == year && s.Day == day);

if (solution is null)
{
    Console.WriteLine($"🔎 No solution found for year {year} and day {day}.");
    Console.WriteLine(usage);
    return;
}
else
{
    solution.RunSolution();
}
