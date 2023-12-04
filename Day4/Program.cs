class Day4
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
        int totalValue = 0;
        foreach (string line in lines)
        {
            string fixedLine = line.Substring(line.IndexOf(":")+2);
            string[] cards = fixedLine.Split(" | ");
            List<int> numbers = cards[0].Trim().Replace("  ", " ").Split(" ").Select(x => Convert.ToInt32(x)).ToList();
            List<int> winningNumbers = cards[1].Trim().Replace("  ", " ").Split(" ").Select(x => Convert.ToInt32(x)).ToList();
            totalValue += (int)Math.Pow(2, numbers.Where(x => winningNumbers.Contains(x)).Count() - 1);
        }
        Console.WriteLine(totalValue);
    }
    static void PartTwo()
    {
        List<int> scratchCards = new List<int>();
        for (int i = 0; i < lines.Length; i++)
            scratchCards.Add(1);
        for(int i = 0; i < lines.Length; i++)
        {
            int value = 0;
            string fixedLine = lines[i].Substring(lines[i].IndexOf(":") + 2);
            string[] cards = fixedLine.Split(" | ");
            List<int> numbers = cards[0].Trim().Replace("  ", " ").Split(" ").Select(x => Convert.ToInt32(x)).ToList();
            List<int> winningNumbers = cards[1].Trim().Replace("  ", " ").Split(" ").Select(x => Convert.ToInt32(x)).ToList();
            value = numbers.Where(x => winningNumbers.Contains(x)).Count();
            for (int j = i+1; j < i+value+1; j++)
            {
                if (j < lines.Length)
                    scratchCards[j] += 1 * scratchCards[i];
            }
        }
        Console.WriteLine(scratchCards.Sum());
    }
}