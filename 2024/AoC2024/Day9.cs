using System.IO.Compression;
using System.Numerics;

public static class Day9
{
    public static void Run()
    {

        string readFile = File.ReadAllText(@"C:\Users\A0828886\01 Repositories\Advent of code\2024\AoC2024\Input\9.txt");
        char[] contents = readFile.ToCharArray();
        // translate to 0...111...2...
        // Move numbers in reverse order into gaps
        // Either loop through doing the moves
        // Or calculate in advance how many to move
        // Sum(position * value)
        var intArray = contents.Select(val => Int64.Parse(val.ToString()));
        var paddedArray = intArray.Select((val, index) => {
            var arr = new long[val];
            Array.Fill(arr, (index % 2 == 0) ? index/2 : -1);
            return arr;
            })
            .SelectMany(arr=>arr).ToArray();

        int lastIndex = paddedArray.Length - 1;

        for (int i = 0; i < paddedArray.Length; i++)
        {
            if (paddedArray[i] == -1)
            {
            while (lastIndex > i && paddedArray[lastIndex] == -1)
            {
                lastIndex--;
            }

            if (lastIndex > i)
            {
                paddedArray[i] = paddedArray[lastIndex];
                paddedArray[lastIndex] = -1;
                lastIndex--;
            }
            }
        }

        //foreach(var item in paddedArray) {Console.WriteLine(item.ToString());}
        long countPartA = paddedArray.TakeWhile(val => val != -1).Select((val, index) => val*index).Sum();
        //var approach2 = intArray.Select((val, index) => (val, index, cumulative: intArray.Take(index+1).Sum()));
        //var spaces = approach2.Where(x => x.index % 2 != 0).ToArray();
        //var files = approach2.Where(x => x.index % 2 == 0).ToArray();
        
        Console.WriteLine($"Answer: {countPartA}");
        
    }
}