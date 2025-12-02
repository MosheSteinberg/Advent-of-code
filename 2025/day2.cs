var lines = File.ReadAllLines("Input/2sample.txt");
var contents = string.Join("", lines);
var answer1 = contents
    .Split(',')
    .Select(s => 
        {
            var parts = s.Split('-');
            return Enumerable.Range(int.Parse(parts[0]), int.Parse(parts[1]) - int.Parse(parts[0]) + 1);
        })
    .SelectMany(x => x)
    .Where(x =>
    {
        var str = x.ToString();
        var lenStr = str.Length;

        if (lenStr % 2 != 0)
            return false;

        var halfLen = lenStr / 2;

        if (str.Substring(0, halfLen) == str.Substring(halfLen, halfLen))
            return true;
        
        return false;
    })
    .Sum();

Console.WriteLine($"Answer 2a: {answer1}");