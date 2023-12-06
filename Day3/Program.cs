class Day3
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
        int totalSum = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if(lines[i][j] != '.' && !IsDigit(lines[i][j]))
                {
                    int num = 0;
                    int k = i, l = j;
                    while(l>0 && IsDigit(lines[i][l-1]))
                    {
                        l--;
                    }
                    while(l<j)
                    {
                        num = num * 10 + lines[i][l]-'0';
                        l++;
                    }
                    totalSum += num;
                    num = 0;
                    k = i;
                    l = j;
                    while (l < lines[i].Length-1 && IsDigit(lines[i][l+1]))
                    {
                        num = num * 10 + lines[i][l+1] - '0';
                        l++;
                    }
                    totalSum += num;
                    num = 0;
                    k = i;
                    l = j;
                    while(l > 0 && k > 0 && IsDigit(lines[k-1][l-1]))
                    {
                        l--;
                    }
                    l--;
                    while (l < lines[i].Length-1 && k > 0 && IsDigit(lines[k - 1][l+1]))
                    {
                        num = num * 10 + lines[k - 1][l+1] - '0';
                        l++;
                    }
                    totalSum += num;
                    num = 0;
                    l++;
                    if (l == j)
                    {
                        while (l < lines[i].Length-1 && k > 0 && IsDigit(lines[k - 1][l + 1]))
                        {
                            num = num * 10 + lines[k-1][l+1] - '0';
                            l++;
                        }
                    }
                    totalSum += num;
                    num = 0;
                    k = i;
                    l = j;
                    while (l > 0 && k < lines.Length-1 && IsDigit(lines[k + 1][l - 1]))
                    {
                        l--;
                    }
                    l--;
                    while (l < lines[i].Length-1 && k < lines.Length-1 && IsDigit(lines[k + 1][l + 1]))
                    {
                        num = num * 10 + lines[k + 1][l + 1] - '0';
                        l++;
                    }
                    totalSum += num;
                    num = 0;
                    l++;
                    if (l == j)
                    {
                        while (l < lines[i].Length-1 && k < lines.Length-1 && IsDigit(lines[k + 1][l + 1]))
                        {
                            num = num * 10 + lines[k + 1][l + 1] - '0';
                            l++;
                        }
                    }
                    totalSum += num;
                }
            }
        }
        Console.WriteLine(totalSum);
    }
    static bool IsDigit(char c) => c >= '0' && c <= '9';
    static int Reverse(int x)
    {
        int result = 0;
        while(x>0)
        {
            result = result * 10 + x % 10;
            x = x / 10;
        }
        return result;
    }
    static void PartTwo()
    {
        int totalSum = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (lines[i][j] == '*')
                {
                    int num = 0, counter = 0, product = 1;
                    int k = i, l = j;
                    while (l > 0 && IsDigit(lines[i][l - 1]))
                    {
                        l--;
                    }
                    while (l < j)
                    {
                        num = num * 10 + lines[i][l] - '0';
                        l++;
                    }
                    counter += num == 0 ? 0 : 1;
                    product *= num != 0 ? num : 1;
                    num = 0;
                    k = i;
                    l = j;
                    while (l < lines[i].Length - 1 && IsDigit(lines[i][l + 1]))
                    {
                        num = num * 10 + lines[i][l + 1] - '0';
                        l++;
                    }
                    counter += num == 0 ? 0 : 1;
                    product *= num != 0 ? num : 1;
                    num = 0;
                    k = i;
                    l = j;
                    while (l > 0 && k > 0 && IsDigit(lines[k - 1][l - 1]))
                    {
                        l--;
                    }
                    l--;
                    while (l < lines[i].Length - 1 && k > 0 && IsDigit(lines[k - 1][l + 1]))
                    {
                        num = num * 10 + lines[k - 1][l + 1] - '0';
                        l++;
                    }
                    counter += num == 0 ? 0 : 1;
                    product *= num != 0 ? num : 1;
                    num = 0;
                    l++;
                    if (l == j)
                    {
                        while (l < lines[i].Length - 1 && k > 0 && IsDigit(lines[k - 1][l + 1]))
                        {
                            num = num * 10 + lines[k - 1][l + 1] - '0';
                            l++;
                        }
                    }
                    counter += num == 0 ? 0 : 1;
                    product *= num != 0 ? num : 1;
                    num = 0;
                    k = i;
                    l = j;
                    while (l > 0 && k < lines.Length - 1 && IsDigit(lines[k + 1][l - 1]))
                    {
                        l--;
                    }
                    l--;
                    while (l < lines[i].Length - 1 && k < lines.Length - 1 && IsDigit(lines[k + 1][l + 1]))
                    {
                        num = num * 10 + lines[k + 1][l + 1] - '0';
                        l++;
                    }
                    counter += num == 0 ? 0 : 1;
                    product *= num != 0 ? num : 1;
                    num = 0;
                    l++;
                    if (l == j)
                    {
                        while (l < lines[i].Length - 1 && k < lines.Length - 1 && IsDigit(lines[k + 1][l + 1]))
                        {
                            num = num * 10 + lines[k + 1][l + 1] - '0';
                            l++;
                        }
                    }
                    counter += num == 0 ? 0 : 1;
                    product *= num != 0 ? num : 1;

                    if (counter == 2)
                        totalSum += product;
                }
            }
        }
        Console.WriteLine(totalSum);
    }
}