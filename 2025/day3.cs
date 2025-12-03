var input = File.ReadLines("Input/3sample.txt");

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

var answer2 = prep
    .Select(row =>
    {
        string result = "";
        for(int i = 0; i < 12; i++)
        {
            // max in all bar last 11 - i positions
            // skipping based on location from previous iteration
            var max = row.Take(row.Count() - (11 - i)).Max();
            var locMax = row.ToList().IndexOf(max);
            result += max.ToString();
            row = row.Skip(locMax + 1);
        }
        return long.Parse(result);
    })
    .Sum();

Console.WriteLine($"Answer 3b: {answer2}");
