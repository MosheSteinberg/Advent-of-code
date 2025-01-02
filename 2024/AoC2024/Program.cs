// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Reflection.Emit;

class Program
{
    static void Main(string[] args)
    {
        // if (args.Length == 0)
        // {
        //     Console.WriteLine("Please provide day number");
        //     return;
        // }

        switch (args.ElementAtOrDefault(0)?.ToLower())
        {
            case "day1":
                Day1.Run();
                break;
            case "day2":
                Day2.Run();
                break;
            case "day3":
                Day3.Run();
                break;
            case "day4":
                Day4.Run();
                break;
            case "day5":
                Day5.Run();
                break;
            case "day6":
                Day6.Run();
                break;
            default:
                Day7.Run();
                break;
        }
    }
}

