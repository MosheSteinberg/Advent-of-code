using System.Data;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

public static class Day4
{
    public static void Run()
    {
        // HttpClient http = new();
        // var response = http.GetAsync("https://adventofcode.com/2024/day/4/input").Result;
        // string input = response.Content.ReadAsStringAsync().Result;
        // Console.WriteLine(input);

        var readFile = File.ReadAllLines(@"C:\Users\A0828886\01 Repositories\Advent of code\2024\AoC2024\Input\4.txt");
        var charArrays = readFile.Select(line => line.ToCharArray()).ToArray();

        var directions = new List<(int, int)>
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, 1),
            (1, 1),
            (1, 0),
            (1, -1),
            (0, -1)
        };

        var rowIndex = 0;
        var countPartA = 0;
        var countPartB = 0;
        foreach (var row in charArrays)
        {
            var columnIndex = 0;
            foreach (var indivChar in row)
            {
                if (indivChar == 'X')
                {
                    foreach (var (rowShift, columnShift) in directions)
                    {
                        try
                        {
                            if (charArrays[rowIndex + rowShift][columnIndex + columnShift] == 'M' &&
                            charArrays[rowIndex + 2 * rowShift][columnIndex + 2 * columnShift] == 'A' &&
                            charArrays[rowIndex + 3 * rowShift][columnIndex + 3 * columnShift] == 'S')
                            {
                                countPartA += 1;
                                //Console.WriteLine($"Match found at row:{rowIndex}, column:{columnIndex}, in direction rows:{rowShift},columns{columnShift}");
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            continue;
                        }
                        
                    }
                }
                if (indivChar == 'A')
                {
                    try
                    {
                        var upperLeft = charArrays[rowIndex-1][columnIndex-1];
                        var upperRight = charArrays[rowIndex-1][columnIndex+1];
                        
                        var lowerLeft = charArrays[rowIndex+1][columnIndex-1];
                        var lowerRight = charArrays[rowIndex+1][columnIndex+1];

                        var backslash = (upperLeft == 'M' && lowerRight == 'S') || (upperLeft == 'S' && lowerRight == 'M');
                        var forwardslash = (upperRight == 'M' && lowerLeft == 'S') || (upperRight == 'S' && lowerLeft == 'M');
                        if (backslash && forwardslash) countPartB += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                }
                columnIndex += 1;
            }
            rowIndex += 1;
        }

        Console.WriteLine($"Part A: {countPartA}");
        Console.WriteLine($"Part B: {countPartB}");
        
    }
}