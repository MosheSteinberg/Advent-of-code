var lines = File.ReadAllLines("Input/1.txt");
var processedList = lines
    .Select(line => (line.Substring(0, 1) == "R" ? 1 : -1) * int.Parse(line.Substring(1)))
    .Prepend(50)
    .Accumulate()
    .Select(x => new PositionLevel(Mod(x, 100), Div(x, 100)) );
var answer = processedList
    .Count(x => x.Position == 0);

Console.WriteLine($"Number of times at position 0: {answer}");

var answer2 = processedList
    .Zip(processedList.Skip(1))
    .Select(pair => 
                Math.Abs(pair.Second.Level - pair.First.Level) // Levels moved
                - (pair.First.Position == 0 & pair.First.Level > pair.Second.Level ? 1 : 0) // Not crossed zero if it started on zero and moved down
                + (pair.Second.Position == 0 & pair.First.Level >= pair.Second.Level ? 1 : 0) // Has crossed zero if it ended on zero even though it hasn't moved down a level
            )
    .Sum();

Console.WriteLine($"Total number of divisions crossed: {answer2}");


static int Mod(int a, int b)
{
    return (a % b + b) % b;
}

static int Div(int a, int b)
{
    return (a - Mod(a, b)) / b;
}

public record struct PositionLevel(int Position, int Level);

public static class IEnumerableExtensions
{
    extension(IEnumerable<int> source)
    {
        public IEnumerable<int> Accumulate()
        {
            int sum = 0;
            foreach (var item in source)
            {
                sum += item;
                yield return sum;
            }
        }
    }
}
