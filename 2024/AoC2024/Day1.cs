public static class Day1
{
    public static void Run()
    {
        var readFile = File.ReadAllLines("Input/1a.txt");
        var contents = new List<string>(readFile);

        List<int> list1 = [];
        List<int> list2 = [];


        foreach (var row in contents){
            var subs = row.Split(' ');

            list1.Add(Int32.Parse(subs[0]));
            list2.Add(Int32.Parse(subs[3]));
        }

        list1.Sort();
        list2.Sort();

        int totaldist = 0;

        for (int i = 0; i < list1.Count; i++) {
            var diff = Math.Abs(list1[i] - list2[i]);
            totaldist += diff;
        }

        Console.WriteLine($"1a: {totaldist}");

        int oneb = 0;
        var occsInList2 = list2.GroupBy(i => i).ToDictionary(grp => grp.Key, grp => grp.Count());


        foreach (int num in list1){
            oneb += num * occsInList2.GetValueOrDefault(num, 0);
        }

        Console.WriteLine($"1b: {oneb}");
    }
}