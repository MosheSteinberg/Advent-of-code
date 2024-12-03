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
            default:
                Day3.Run();
                break;
        }
    }
}

