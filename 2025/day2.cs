var lines = File.ReadAllLines("Input/2.txt");
var contents = string.Join("", lines);
var answer1 = contents
    .Split(',')
    .Select(s => 
        {
            var parts = s.Split('-');
            return CreateRange(long.Parse(parts[0]), long.Parse(parts[1]));
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

static IEnumerable<long> CreateRange(long start, long end)
{
    while (start <= end)
    {
        yield return start;
        start++;
    }
}