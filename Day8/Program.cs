using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Text;

class Day8
{
    //static string[] input = File.ReadAllLines("../../../testInput.txt");
    static string[] input = File.ReadAllLines("../../../input.txt");

    static Dictionary<string, (string, string)> graph = new Dictionary<string, (string, string)>();
    static Dictionary<string, int> visits = new Dictionary<string, int>();

    static string path = input[0];
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    static void PartOne()
    {
        int counter = 0, steps = 0;
        string current = "AAA";
        for(int i = 2; i < input.Length; i++)
        {
            string[] line = input[i].Split(" = ");
            string[] destination = line[1].Substring(1, line[1].Length - 2).Split(", ");
            graph.Add(line[0], (destination[0], destination[1]));
            visits.Add(line[0], 0);
        }
        while(current != "ZZZ")
        {
            if (path[counter] == 'L')
                current = graph[current].Item1;
            else
                current = graph[current].Item2;
            counter++;
            if (counter == path.Length)
                counter = 0;
            steps++;
        }
        Console.WriteLine(steps);
    }
    static void PartTwo()
    {
        List<string> startringPoints = graph.Keys.Where(x=>x.EndsWith('A')).ToList();
        List<long> steps = new List<long>();

        foreach(string p in startringPoints)
        {
            string point = p;
            int counter = 0;
            while(!point.EndsWith('Z'))
            {
                for (int i = 0; i < path.Length; i++)
                {
                    if (path[i] == 'L')
                        point = graph[point].Item1;
                    else
                        point = graph[point].Item2;
                }
                counter++;
            }
            steps.Add(counter);
        }

        long result = 1;

        for(int i = 0; i < steps.Count; i++)
        {
            result = LCM(result, steps[i]);
        }

        Console.WriteLine(result * path.Length);
    }
    static long GCF(long a, long b)
    {
        while(b!=0)
        {
            long c = b;
            b = a % b;
            a = c;
        }
        return a;
    }
    static long LCM(long a, long b)
    {
        return (a / GCF(a, b)) * b;
    }
}