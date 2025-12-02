var lines = File.ReadAllLines("Input/1.txt");
var processedList = lines
    .Select(line => (line.Substring(0, 1) == "R" ? 1 : -1) * int.Parse(line.Substring(1)))
    .Prepend(50)
    .Accumulate()
    .Select(x => new PositionLevel(Mod(x, 100), Div(x, 100)) );
var answer = processedList
    .Count(x => x.Position == 0);
Console.WriteLine($"Number of times at position 0: {answer}");


var bla = processedList
    .Zip(processedList.Skip(1))
    .Select(pair => Math.Abs(pair.Second.Level - pair.First.Level) - (pair.First.Position == 0 & pair.First.Level > pair.Second.Level ? 1 : 0) + (pair.Second.Position == 0 & pair.First.Level >= pair.Second.Level ? 1 : 0));
    //.Sum();

var foo = lines
    .Select(line => (line.Substring(0, 1) == "R" ? 1 : -1) * int.Parse(line.Substring(1)))
    .Prepend(50)
    .Accumulate();

var z = foo
    .Zip(foo.Skip(1))
    .Select(pair =>
    {
        var range = Enumerable.Range(Math.Min(pair.First, pair.Second), Math.Abs(pair.Second - pair.First)+1)
            .ToList();
        range.Remove(pair.First); // remove starting point to avoid double counting
        return range
            .Select(x => Mod(x, 100))
            .Count(x => x == 0);
    }
    );

// foreach ( var item in z )
// {
//     Console.WriteLine($"Range: {string.Join(", ", item)}");
// }
// for(var i = 0; i < processedList.Count(); i++) 
// {
//     Console.WriteLine($"Position: {processedList.ElementAt(i).Position}, Level: {processedList.ElementAt(i).Level}");
//     Console.WriteLine($"Moves: {bla.ElementAtOrDefault(i)}");
// }

Console.WriteLine($"Total number of divisions crossed: {bla.Sum()}");


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
