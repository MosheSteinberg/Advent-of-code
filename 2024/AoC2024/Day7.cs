using System.IO.Compression;

public static class Day7
{
    public static void Run()
    {

        string[] readFile = File.ReadAllLines(@"C:\Users\A0828886\01 Repositories\Advent of code\2024\AoC2024\Input\7.txt");
        
        var formattedInput = readFile
                                .Select(x => x.Split(": ", StringSplitOptions.None))
                                .ToDictionary(x => Int64.Parse(x[0]), x => x[1].Split(' ').Select(y => Int64.Parse(y)).ToList());

        long countAnswer = formattedInput
            .Where( kv => AllCombos(kv.Value).Contains(kv.Key))
            .Sum(kv => kv.Key);

        Console.WriteLine($"Answer: {countAnswer}");
        
    }

    public static List<long> AllCombos(List<long> listValues)
    {

        List<long> vals = [listValues[0]];
        for (int i = 1; i < listValues.Count; i++)
        {
            List<long> newVals = [];
            foreach (var val in vals)
            {
                newVals.Add(val + listValues[i]);
                newVals.Add(val * listValues[i]);
                // Comment next line out for part A
                newVals.Add(Int64.Parse(val.ToString() + listValues[i].ToString()));
            }
            vals = newVals;
        }
        return vals;
    }

}
