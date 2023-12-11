using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Text;

class Day8
{
    //static string[] input = File.ReadAllLines("../../../testInput.txt");
    static string[] input = File.ReadAllLines("../../../input.txt");
    static Dictionary<string, (string, string)> graph = new Dictionary<string, (string, string)>();
    static Dictionary<string, int> visits = new Dictionary<string, int>();
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    static void PartOne()
    {
        int counter = 0, steps = 0;
        string path = input[0];
        string current = "AAA";
        for(int i = 2; i < input.Length; i++)
        {
            string[] line = input[i].Split(" = ");
            string[] destination = line[1].Substring(1, line[1].Length - 2).Split(", ");
            graph.Add(line[0], (destination[0], destination[1]));
            visits.Add(line[0], 0);
        }
        /*while(current != "ZZZ")
        {
            if (path[counter] == 'L')
                current = graph[current].Item1;
            else
                current = graph[current].Item2;
            counter++;
            if (counter == path.Length)
                counter = 0;
            steps++;
        }*/
        Console.WriteLine(steps);
    }
    static void PartTwo()
    {
        List<string> startringPoints = graph.Keys.Where(x=>x.EndsWith('A')).ToList();

        Traverse(startringPoints[0], 0, new StringBuilder());
        Console.WriteLine(cnt);
    }
    static int cnt = 0;
    static void Traverse(string point, int counter, StringBuilder sb)
    {
        visits[point] += 1;
        if (point.EndsWith('Z'))
        {
            counter++;
            cnt++;
            Console.WriteLine(sb);
            return;
        }

        if (visits[graph[point].Item1] < 2)
        {
            Traverse(graph[point].Item1, counter, sb.Append("L"));
        }
        if(visits[graph[point].Item2] < 2)
        {
            Traverse(graph[point].Item2, counter, sb.Append("R"));
        }

        sb.Remove(sb.Length - 1, 1);
        visits[point] -= 1;
    }
    //static void Traverse(List<string> points, char c, int counter)
    //{
    //    if (points.All(x => x.EndsWith('Z')))
    //        Console.WriteLine(counter);
    //    if (c == 'L')
    //    {
    //        for (int i = 0; i < points.Count; i++)
    //            points[i] = graph[points[i]].Item1;
    //    }
    //    else
    //    {
    //        for (int i = 0; i < points.Count; i++)
    //            points[i] = graph[points[i]].Item2;
    //    }
    //    Traverse(points, 'L', counter + 1);
    //    Traverse(points, 'R', counter + 1);
    //}
}