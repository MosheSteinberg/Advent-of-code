var lines = File.ReadAllLines("Input/2.txt");
var contents = string.Join("", lines);
var allIds = contents
    .Split(',')
    .Select(s => 
        {
            var parts = s.Split('-');
            return CreateRange(long.Parse(parts[0]), long.Parse(parts[1]));
        })
    .SelectMany(x => x);

var answer1 = allIds
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

var answer2 = allIds
    .Where(x =>
    {
        var str = x.ToString();
        return IsStringRepeated(x.ToString());
    })
    .Sum();

Console.WriteLine($"Answer 2b: {answer2}");

static IEnumerable<long> CreateRange(long start, long end)
{
    while (start <= end)
    {
        yield return start;
        start++;
    }
}

static IEnumerable<(int, int)> GetDivisors(int number)
{
    for (int i = 1; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            yield return (i, number / i);
        }
    }
}

static bool IsStringRepeated(string str)
{
    var lenStr = str.Length;

    foreach(var (x, y) in GetDivisors(lenStr))
    {
        for (int part = 1; part < y; part++)
        {
            if (str.Substring(0, x) != str.Substring(part * x, x))
                break;

            if (part == y - 1)
                return true;
        }

        for (int part = 1; part < x; part++)
        {
            if (str.Substring(0, y) != str.Substring(part * y, y))
                break;

            if (part == x - 1)
                return true;
        }
    }
    return false;
}