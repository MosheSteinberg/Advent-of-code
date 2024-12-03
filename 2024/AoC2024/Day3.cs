using System.Text.RegularExpressions;

public static class Day3
{
    public static void Run()
    {
        var readFile = File.ReadAllText("Input/3.txt");
        var matches = Regex.Matches(readFile, @"mul\(\d+,\d+\)");
        var dos = Regex.Matches(readFile, @"do\(\)");
        // Console.WriteLine($"Number of dos: {dos.Count}");
        var donts = Regex.Matches(readFile, @"don't\(\)");

        var totalPartA = 0;
        var totalPartB = 0;
        foreach (Match match in matches)
        {
            // Console.WriteLine(match);
            var numbers = Regex.Matches(match.Value, @"\d+");
            if (numbers.Count == 2)
            {
            int num1 = int.Parse(numbers[0].Value);
            int num2 = int.Parse(numbers[1].Value);
            int result = num1 * num2;
            totalPartA += result;
            int lastDont = donts.Where(d => d.Index < match.Index).Select(d => d.Index).DefaultIfEmpty(-2).Max();
            // Console.WriteLine(lastDont);
            int lastDo = dos.Where(d => d.Index < match.Index).Select(d => d.Index).DefaultIfEmpty(-1).Max();
            // Console.WriteLine(lastDo);
            if (!(lastDont > lastDo))
            {
                totalPartB += result;
            }
            }
        }
        Console.WriteLine($"Part a: {totalPartA}");
        Console.WriteLine($"Part b: {totalPartB}");
        
    }
}