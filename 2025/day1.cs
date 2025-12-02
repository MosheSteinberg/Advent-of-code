var lines = File.ReadAllLines("Input/1.txt");
var answer = lines
    .Select(line => (line.Substring(0, 1) == "R" ? 1 : -1) * int.Parse(line.Substring(1)))
    .Prepend(50)
    .AccumulateModulo100()
    .Count(x => x == 0);
Console.WriteLine($"Number of times at position 0: {answer}");

public static class IEnumerableExtensions
{
    extension(IEnumerable<int> source)
    {
        public IEnumerable<int> AccumulateModulo100()
        {
            int sum = 0;
            foreach (var item in source)
            {
                sum = (sum + item) % 100;
                yield return sum;
            }
        }
    }
    
}