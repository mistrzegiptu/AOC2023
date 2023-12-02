using System.Globalization;

class Day1
{
    static Dictionary<string, int> stringDigit = new Dictionary<string, int>()
    {
        {"one", 1 },
        {"two", 2 },
        {"three", 3 },
        {"four", 4 },
        {"five", 5 },
        {"six", 6 },
        {"seven", 7 },
        {"eight", 8 },
        {"nine", 9 },
        {"zero", 0 },
    };
    static string[] inputLines = File.ReadAllLines("..\\..\\..\\input.txt");
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    static void PartOne()
    {
        int totalSum = 0;

        foreach (var item in inputLines)
        {
            int left = -1, right = -1;
            for (int i = 0; i < item.Length; i++)
            {
                if (IsDigit(item[i]))
                {
                    if (left == -1)
                    {
                        left = item[i] - '0';
                        right = left;
                    }
                    else
                    {
                        right = item[i] - '0';
                    }
                }
            }
            totalSum += left * 10 + right;
        }
        Console.WriteLine(totalSum);
    }
    static void PartTwo()
    {
        int totalSum = 0;
        
        foreach (string line in inputLines)
        {
            string fixedLine = "";
            int left = -1, right = -1;

            for (int i = 0; i < line.Length; i++)
            {
                if (IsDigit(line[i]))
                    fixedLine += line[i];
                else
                {
                    for (int j = i+1; j < line.Length; j++)
                    {
                        if(stringDigit.ContainsKey(line.Substring(i, (j-i+1))))
                        {
                            fixedLine += stringDigit[line.Substring(i, (j-i+1))];
                        }
                    }
                }
            }
            for (int i = 0; i < fixedLine.Length; i++)
            {
                if (IsDigit(fixedLine[i]))
                {
                    if (left == -1)
                    {
                        left = fixedLine[i] - '0';
                        right = left;
                    }
                    else
                    {
                        right = fixedLine[i] - '0';
                    }
                }
            }
            totalSum += left * 10 + right;
        }
        Console.WriteLine(totalSum);
    }
    static bool IsDigit(char c) => c >= '0' && c <= '9';
}