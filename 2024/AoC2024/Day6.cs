
using System.IO.Compression;

public static class Day6
{
    public static void Run()
    {

        string[] readFile = File.ReadAllLines(@"C:\Users\A0828886\01 Repositories\Advent of code\2024\AoC2024\Input\6.txt");
        char[][] charArrays = readFile.Select(line => line.ToCharArray()).ToArray();

        int height = charArrays.Length;
        int width = charArrays[0].Length;

        List<Step> locations = [];

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

        Direction dir = Direction.Up;

        locations.Add(new Step(position.rowIndex, position.colIndex, dir));

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
                    .Select(x => new Step(x.rowIndex, position.colIndex, dir)));

                
                position = new {position.ch, locations.Last().rowIndex, position.colIndex}; 
            }
            else if (dir == Direction.Up)
            {
                locations.AddRange(charArrays
                .Select((row, rowIndex) => new {value = row[position.colIndex], rowIndex})
                .Reverse()
                .Skip(height - position.rowIndex)
                .TakeWhile(x => x.value != '#')
                .Select(x => new Step(x.rowIndex, position.colIndex, dir)));

                position = new {position.ch, locations.Last().rowIndex, position.colIndex}; 
            }
            else if (dir == Direction.Right)
            {
                locations.AddRange(charArrays[position.rowIndex]
                                    .Select((col, colIndex) => new {col, colIndex})
                                    .Skip(position.colIndex + 1)
                                    .TakeWhile(c => c.col != '#')
                                    .Select(val => new Step(position.rowIndex, val.colIndex, dir)));

                position = new {position.ch, position.rowIndex, locations.Last().colIndex}; 
            }
            else // left
            {
                locations.AddRange(charArrays[position.rowIndex]
                                    .Select((col, colIndex) => new {col, colIndex})
                                    .Reverse()
                                    .Skip(width - position.colIndex)
                                    .TakeWhile(c => c.col != '#')
                                    .Select(val => new Step(position.rowIndex, val.colIndex, dir)));
                
                position = new {position.ch, position.rowIndex, locations.Last().colIndex}; 
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
        
        int countPartA = locations.Distinct(new TupleComparer()).Count();


        Console.WriteLine($"Part A: {countPartA}");
        // Console.WriteLine($"Part B: {countPartB}");
        
    }

}

public enum Direction
        {
            Up,
            Right,
            Down,
            Left
        };

public class Step(int rowIndex, int colIndex, Direction dir)
{
    public int rowIndex = rowIndex;
    public int colIndex = colIndex;
    public Direction dir = dir;
}
public class TupleComparer : IEqualityComparer<Step>
{
    public bool Equals(Step x, Step y)
    {
        return x.rowIndex == y.rowIndex && x.colIndex == y.colIndex;
    }

    public int GetHashCode(Step obj)
    {
        return HashCode.Combine(obj.rowIndex, obj.colIndex);
    }
}