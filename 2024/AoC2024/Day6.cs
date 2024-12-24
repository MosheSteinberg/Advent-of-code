
using System.IO.Compression;

public static class Day6
{
    enum Direction
        {
            Up,
            Right,
            Down,
            Left
        };
    public static void Run()
    {

        string[] readFile = File.ReadAllLines(@"C:\Users\A0828886\01 Repositories\Advent of code\2024\AoC2024\Input\6.txt");
        char[][] charArrays = readFile.Select(line => line.ToCharArray()).ToArray();

        int height = charArrays.Length;
        int width = charArrays[0].Length;

        List<(int,int)> locations = [];

        //charArrays.SelectMany(ch => (ch, ch.In))
        // Find the starting position of the given character
        
        var position = charArrays
            .SelectMany((row, rowIndex) => row.Select((ch, colIndex) => new { ch, rowIndex, colIndex }))
            .FirstOrDefault(x => x.ch == '^');

        Console.WriteLine(position);

        if (position == null)
        {
            Console.WriteLine("^ not found.");
            return;
        }

        locations.Add((position.rowIndex, position.colIndex));

        Direction dir = Direction.Up;
        bool onmap = true;
        while (onmap)
        {
            Console.WriteLine($"Currect direction: {dir}");
            if (dir == Direction.Down)
            {
                locations.AddRange(charArrays
                    .Select((row, rowIndex) => new { value = row[position.colIndex], rowIndex })
                    .Skip(position.rowIndex + 1)
                    .TakeWhile(x => x.value != '#')
                    .Select(x => (x.rowIndex, position.colIndex)));

                
                position = new {position.ch, rowIndex = locations.Last().Item1, position.colIndex}; 
            }
            else if (dir == Direction.Up)
            {
                locations.AddRange(charArrays
                .Select((row, rowIndex) => new {value = row[position.colIndex], rowIndex})
                .Reverse()
                .Skip(height - position.rowIndex)
                .TakeWhile(x => x.value != '#')
                .Select(x => (x.rowIndex, position.colIndex)));

                position = new {position.ch, rowIndex = locations.Last().Item1, position.colIndex}; 
            }
            else if (dir == Direction.Right)
            {
                locations.AddRange(charArrays[position.rowIndex]
                                    .Select((col, colIndex) => new {col, colIndex})
                                    .Skip(position.colIndex + 1)
                                    .TakeWhile(c => c.col != '#')
                                    .Select(val => (position.rowIndex, val.colIndex)));

                position = new {position.ch, position.rowIndex, colIndex = locations.Last().Item2}; 
            }
            else // left
            {
                locations.AddRange(charArrays[position.rowIndex]
                                    .Select((col, colIndex) => new {col, colIndex})
                                    .Reverse()
                                    .Skip(width - position.colIndex)
                                    .TakeWhile(c => c.col != '#')
                                    .Select(val => (position.rowIndex, val.colIndex)));
                
                position = new {position.ch, position.rowIndex, colIndex = locations.Last().Item2}; 
            }

            int index = (int)dir;
            index = ++index % 4;
            dir = (Direction)index;

            Console.WriteLine($"Current position: {position}");

            if (position.rowIndex == 0 || position.colIndex == 0 || position.rowIndex == height-1 || position.colIndex == width - 1)
            {
                break;
            }
            // Check if # found in the given direction
            // If yes, move to next to it and change dir
            // count number of places along the way
            // If no, count number of places to edge and break
        }
        
        int countPartA = locations.Distinct().Count();

        Console.WriteLine($"Part A: {countPartA}");
        // Console.WriteLine($"Part B: {countPartB}");
        
    }
}