struct MappingValues
{
    public long destination, source, length;
    public MappingValues(long destination, long source, long length)
    {
        this.destination = destination;
        this.source = source;
        this.length = length;
    }
}
class Day5
{
    //static string[] input = File.ReadAllLines("../../../testInput.txt");
    static string[] input = File.ReadAllLines("../../../input.txt");
    static List<List<MappingValues>> maps = new List<List<MappingValues>>();
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    public static void PartOne()
    {
        long[] seeds = input[0].Substring(7).Split(" ").Select(x => Convert.ToInt64(x)).ToArray();
        long lowestLocation = long.MaxValue;
        int line = 1, i = -1;
        while(line < input.Length)
        {
            if (String.IsNullOrEmpty(input[line]))
            {
                maps.Add(new List<MappingValues>());
                i++;
                line++;
            }
            else
            {
                long[] values = input[line].Split(" ").Select(x => Convert.ToInt64(x)).ToArray();
                maps[i].Add(new MappingValues(values[0], values[1], values[2]));
            }
            line++;
        }

        foreach (var seed in seeds)
        {
            lowestLocation = lowestLocation > GetLocation(seed) ? GetLocation(seed) : lowestLocation;
        }
        Console.WriteLine(lowestLocation);
    }
    public static void PartTwo()
    {
        long[] seeds = input[0].Substring(7).Split(" ").Select(x => Convert.ToInt64(x)).ToArray();
        long lowestLocation = long.MaxValue;
        int line = 1, i = -1;

        for(int j = 0; j < seeds.Length-1; j+=2)
        {
            for (long k = 0; k < seeds[j+1]; k++)
            {
                lowestLocation = lowestLocation > GetLocation(seeds[j] + k) ? GetLocation(seeds[j] + k) : lowestLocation;
            }
        }
        Console.WriteLine(lowestLocation);
    }
    public static long GetLocation(long seed)
    {
        int i = 0;
        long dest = seed, source = seed;
        while(i < maps.Count)
        {
            dest = source;
            for(int mapIterator = 0; mapIterator < maps[i].Count; mapIterator++)
            {
                if (source >= maps[i][mapIterator].source && source < (maps[i][mapIterator].source + maps[i][mapIterator].length))
                {
                    dest = (source - maps[i][mapIterator].source) + maps[i][mapIterator].destination;
                }
            }
            source = dest;
            i++;
        }
        return source;
    }
}