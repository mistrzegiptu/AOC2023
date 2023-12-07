using System.Text.RegularExpressions;

class Day6
{
    //static string[] lines = File.ReadAllLines("../../../testInput.txt");
    static string[] lines = File.ReadAllLines("../../../input.txt");
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    static void PartOne()
    {
        int result = 1;
        string[] times = Regex.Split(lines[0].Substring(lines[0].IndexOf(":")+1).Trim(), @"\s{2,}");
        string[] distances = Regex.Split(lines[1].Substring(lines[1].IndexOf(":")+1).Trim(), @"\s{2,}");

        for(int i = 0; i < times.Length; i++)
        {
            int record = Convert.ToInt32(distances[i]);
            int time = Convert.ToInt32(times[i]);
            int counter = 0;
            for(int j = 0; j <= time; j++)
            {
                if (j * (time - j) > record)
                    counter++;
            }
            result *= counter;
        }
        Console.WriteLine(result);
    }
    static void PartTwo()
    {
        string time = Regex.Replace(lines[0].Substring(lines[0].IndexOf(":") + 1), @"\s", "");
        string distance = Regex.Replace(lines[1].Substring(lines[1].IndexOf(":") + 1), @"\s", "");
        double dist = Convert.ToDouble(distance);
        double t = Convert.ToDouble(time);
        double delta = Math.Sqrt(t * t - 4 * dist);
        double x1 = (t - delta) / 2;
        double x2 = (t + delta) / 2;

        Console.WriteLine(Math.Abs(Math.Ceiling(x1)-Math.Floor(x2))+1);
    }
}