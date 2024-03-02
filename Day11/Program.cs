class Day11
{
    static string[] input = File.ReadAllLines("../../../testInput.txt");
    //static string[] input = File.ReadAllLines("../../../input.txt");
    static char[][] map = input.Select(x => x.Select(y => y).ToArray()).ToArray();
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    public static void PartOne()
    {
        int newRows = CountEmptyRow() * 2 + map.Length;
        int newCols = CountEmptyColumn() * 2 + map[0].Length;
        char[,] newMap = new char[newRows, newCols];
        Console.WriteLine(CountEmptyRow() + " " + CountEmptyColumn());
    }
    public static int CountEmptyRow()
    {
        int counter = 0;

        for (int i = 0; i < map.Length; i++)
        {
            bool empty = true;
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '#')
                    empty = false;
            }
            if(empty)
                counter++;
        }
        return counter;
    }
    public static int CountEmptyColumn()
    {
        int counter = 0;

        for (int i = 0; i < map.Length; i++)
        {
            bool empty = true;
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[j][i] == '#')
                    empty = false;
            }
            if (empty)
                counter++;
        }
        return counter;
    }
    public static void PartTwo()
    {

    }
}