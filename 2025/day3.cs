var input = File.ReadLines("Input/3.txt");

var prep = input
    .Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())));
var answer1 = prep
    .Select(row => 
    {
        var max = row.Take(row.Count() - 1).Max();
        var locMax = row.ToList().IndexOf(max);
        var maxPostMax = row.Skip(locMax+1).Max();
        return int.Parse(max.ToString() + maxPostMax.ToString());
    })
    .Sum();

Console.WriteLine($"Answer 3a: {answer1}");