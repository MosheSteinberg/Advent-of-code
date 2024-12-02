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
            var countIncreasing = incremental.Count(i => (i >=1 && i <=3));
            var countDecreasing = incremental.Count(i => (i <= -1 && i >= -3));
            if (countIncreasing == length || countDecreasing == length)
            {
                partAcount +=1;
                Console.WriteLine($"{iteration} is good");
            }
            else if (countIncreasing == length - 1)
            {
                var index = incremental.Select((value, idx) => new { value, idx })
                                       .FirstOrDefault(pair => !(pair.value >= 1 && pair.value <= 3))?.idx ?? -1;
                var cumulated = incremental.ElementAt(index) + incremental.ElementAtOrDefault(index+1);
                if (index == 0 || index == length-1 || (cumulated >=1 && cumulated <=3))
                {
                    partBcount +=1;
                    Console.WriteLine($"{iteration} is ^1skip");
                }
            }
            else if (countDecreasing == length - 1)
            {
                var index = incremental.Select((value, idx) => new { value, idx })
                                       .FirstOrDefault(pair => !(pair.value <= -1 && pair.value >= -3))?.idx ?? -1;
                var cumulated = incremental.ElementAt(index) + incremental.ElementAtOrDefault(index+1);
                if (index == 0 || index == length-1 || (cumulated <=-1 && cumulated >= -3))
                {
                    partBcount +=1;
                    Console.WriteLine($"{iteration} is dwn1skip");


                }
            }
        }

        Console.WriteLine($"2a: {partAcount}");
        Console.WriteLine($"2b: {partAcount + partBcount}");
    }
}