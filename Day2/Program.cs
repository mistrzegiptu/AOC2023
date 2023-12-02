class Day2
{
    static string[] lines = File.ReadAllLines("..\\..\\..\\input.txt"); 
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    static void PartOne()
    {
        int sumOfIndexes = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Substring(lines[i].IndexOf(':')+2);
            string[] games = line.Split(';');
            int red = 0, green = 0, blue = 0;
            bool overflow = false;
            foreach (string game in games)
            {
                string[] colours = game.Trim().Split(", ");
                foreach (string colour in colours)
                {
                    switch (colour.Split(" ")[1])
                    {
                        case "red":
                            red += Convert.ToInt32(colour.Split(" ")[0]);
                            break;
                        case "green":
                            green += Convert.ToInt32(colour.Split(" ")[0]);
                            break;
                        case "blue":
                            blue += Convert.ToInt32(colour.Split(" ")[0]);
                            break;
                    }
                    if (red > 12 || green > 13 || blue > 14)
                    {
                        overflow = true;
                        break;
                    }
                }
                red = green = blue = 0;
            }
            if(!overflow)
                sumOfIndexes += i + 1;
        }
        Console.WriteLine(sumOfIndexes);
    }
    static void PartTwo()
    {
        int sumOfPowers = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Substring(lines[i].IndexOf(':') + 2);
            string[] games = line.Split(';');
            int red = 0, green = 0, blue = 0;
            foreach (string game in games)
            {
                string[] colours = game.Trim().Split(", ");
                foreach (string colour in colours)
                {
                    switch (colour.Split(" ")[1])
                    {
                        case "red":
                            red = Max(Convert.ToInt32(colour.Split(" ")[0]), red);
                            break;
                        case "green":
                            green = Max(Convert.ToInt32(colour.Split(" ")[0]), green);
                            break;
                        case "blue":
                            blue = Max(Convert.ToInt32(colour.Split(" ")[0]), blue);
                            break;
                    }
                }
            }
            sumOfPowers += (red * green * blue);
        }
        Console.WriteLine(sumOfPowers);
    }
    static int Max(int a, int b) => a >= b ? a : b;
}