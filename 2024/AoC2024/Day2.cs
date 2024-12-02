public static class Day2
{
    public static void Run()
    {
        var readFile = File.ReadAllLines("Input/2.txt");
        var contents = new List<string>(readFile);
        var listOfLists = contents
            .Select(line => line.Split(' ')
            .Select(int.Parse)
            .ToList())
            .ToList();

        Console.WriteLine($"Number of lists: {listOfLists.Count()}");

        var partAcount = 0;
        var partBcount = 0;
        var iteration = 0;
        foreach (var report in listOfLists)
        {
            iteration +=1;
            var incremental = report.Zip(report.Skip(1), (x,y) => y-x);
            var length = incremental.Count();
            var countIncreasing = incremental.Count(i => i >=1 && i <=3);
            var countDecreasing = incremental.Count(i => i <= -1 && i >= -3);
            if (countIncreasing == length || countDecreasing == length)
            {
                partAcount +=1;
                Console.WriteLine($"{iteration} is good");
            }
            else
            {
                // Check by skipping one element
                for (int i = 0; i < report.Count; i++)
                {
                    var skippedReport = report.Where((_, index) => index != i).ToList();
                    var skippedIncremental = skippedReport.Zip(skippedReport.Skip(1), (x, y) => y - x).ToList();
                    var skippedLength = skippedIncremental.Count;
                    var skippedCountIncreasing = skippedIncremental.Count(j => j >= 1 && j <= 3);
                    var skippedCountDecreasing = skippedIncremental.Count(j => j <= -1 && j >= -3);

                    if (skippedCountIncreasing == skippedLength || skippedCountDecreasing == skippedLength)
                    {
                        partBcount += 1;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"2a: {partAcount}");
        Console.WriteLine($"2b: {partAcount + partBcount}");
    }
}