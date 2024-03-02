class Day10
{
    //static string[] input = File.ReadAllLines("../../../testInput.txt");
    static string[] input = File.ReadAllLines("../../../input.txt");
    static char[][] pipes = input.Select(x => x.ToCharArray().Select(y => y).ToArray()).ToArray();
    static bool[,] proceeded = new bool[pipes.Length, pipes[0].Length];
    static int[,] distances = new int[pipes.Length, pipes[0].Length];
    static List<(int, int)> vertices = new List<(int, int)> ();
    public static void Main()
    {
        (int, int) startIndex = (0, 0);
        for (int i = 0; i < pipes.Length; i++)
        {
            for (int j = 0; j < pipes[0].Length; j++)
            {
                if (pipes[i][j] == 'S')
                    startIndex = (i, j);
            }
        }
        PartOne(startIndex);
        PartTwo(startIndex);
    }
    public static void PartOne((int, int) startIndex)
    {   
        MoveUntillEnd(startIndex, (startIndex.Item1 + 1, startIndex.Item2));
        MoveUntillEnd(startIndex, (startIndex.Item1, startIndex.Item2 + 1));
        MoveUntillEnd(startIndex, (startIndex.Item1 - 1, startIndex.Item2));
        MoveUntillEnd(startIndex, (startIndex.Item1, startIndex.Item2 - 1));

        /*for (int i = 0; i < pipes.Length; i++)
        {
            for (int j = 0; j < pipes[0].Length; j++)
            {
                Console.Write(distances[i, j] + "  ");
            }
            Console.WriteLine();
        }*/
        Console.WriteLine(distances.Cast<int>().Max());
    }
    public static void MoveUntillEnd((int, int) startingIndex, (int, int) afterStart)
    {
        int depth = 1;
        (int, int) lastIndex = startingIndex;
        (int, int) currentIndex = afterStart;

        if (afterStart.Item1 < 0 || afterStart.Item2 < 0 || afterStart.Item1 >= pipes.Length || afterStart.Item2 >= pipes[0].Length)
            return;

        while (CanMove(lastIndex, currentIndex) && pipes[currentIndex.Item1][currentIndex.Item2] != 'S')
        {
            distances[currentIndex.Item1, currentIndex.Item2] = distances[currentIndex.Item1, currentIndex.Item2] != 0 ? Math.Min(depth, distances[currentIndex.Item1, currentIndex.Item2]) : depth;
            var dupa = currentIndex;
            currentIndex = Move(lastIndex, currentIndex);
            lastIndex = dupa;
            depth++;
        }
    }
    public static bool CanMove((int, int) lastIndex, (int, int) currentIndex) 
    {
        int deltaX = currentIndex.Item1 - lastIndex.Item1;
        int deltaY = currentIndex.Item2 - lastIndex.Item2;

        if (deltaX == 1 && deltaY == 0)
            return pipes[currentIndex.Item1][currentIndex.Item2] == '|' || pipes[currentIndex.Item1][currentIndex.Item2] == 'J' || pipes[currentIndex.Item1][currentIndex.Item2] == 'L';
        else if (deltaX == -1 && deltaY == 0)
            return pipes[currentIndex.Item1][currentIndex.Item2] == '|' || pipes[currentIndex.Item1][currentIndex.Item2] == 'F' || pipes[currentIndex.Item1][currentIndex.Item2] == '7';
        else if (deltaX == 0 && deltaY == 1)
            return pipes[currentIndex.Item1][currentIndex.Item2] == '-' || pipes[currentIndex.Item1][currentIndex.Item2] == 'J' || pipes[currentIndex.Item1][currentIndex.Item2] == '7';
        else if (deltaX == 0 && deltaY == -1)
            return pipes[currentIndex.Item1][currentIndex.Item2] == '-' || pipes[currentIndex.Item1][currentIndex.Item2] == 'F' || pipes[currentIndex.Item1][currentIndex.Item2] == 'L';
        return false;
    }
    public static (int, int) Move((int, int) starting, (int, int) destination)
    {
        switch (pipes[destination.Item1][destination.Item2]) 
        {
            case '|':
                return destination.Item1 - starting.Item1 == 1 ? (destination.Item1+1, destination.Item2) : (destination.Item1-1, destination.Item2);
            case '-':
                return destination.Item2 - starting.Item2 == 1 ? (destination.Item1, destination.Item2 + 1) : (destination.Item1, destination.Item2 - 1);
            case 'L':
                vertices.Add(destination);
                return destination.Item1 - starting.Item1 == 1 ? (destination.Item1, destination.Item2 + 1) : (destination.Item1 - 1, destination.Item2);
            case 'J':
                vertices.Add(destination);
                return destination.Item1 - starting.Item1 == 1 ? (destination.Item1, destination.Item2 - 1) : (destination.Item1 - 1, destination.Item2);
            case '7':
                vertices.Add(destination);
                return destination.Item1 - starting.Item1 == -1 ? (destination.Item1, destination.Item2 - 1) : (destination.Item1 + 1, destination.Item2);
            case 'F':
                vertices.Add(destination);
                return destination.Item1 - starting.Item1 == -1 ? (destination.Item1, destination.Item2 + 1) : (destination.Item1 + 1, destination.Item2);
            default: 
                return destination;
        }
    }
    public static void PartTwo((int, int) startIndex)
    {
        int A = 0;
        vertices = vertices.GroupBy(x => x).Select(y => y.First()).ToList();
        vertices.Insert(0, startIndex);

        //Shoelace formula
        for (int i = 0; i < vertices.Count-1; i++)
        {
            A += vertices[i].Item1 * vertices[i + 1].Item2 - vertices[i].Item2 * vertices[i + 1].Item1;
        }
        A += vertices.Last().Item1 * vertices[0].Item2 - vertices.Last().Item2 * vertices[0].Item1;

        //Pick's theorem
        int b = distances.Cast<int>().Max();
        int I = A / 2 - b + 1;
        Console.WriteLine(I);
    }
}