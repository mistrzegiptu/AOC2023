class Day9
{
    //static string[] input = File.ReadAllLines("../../../testInput.txt");
    static string[] input = File.ReadAllLines("../../../input.txt");
    public static void Main()
    {
        PartOne();
        PartTwo();
    }
    static void PartOne()
    {
        int sum = 0;
        foreach(string line in input)
        {
            int index = 1;
            string[] nums = line.Split(" ");
            List<List<int>> sequences = new List<List<int>>();
            sequences.Add(new List<int>());
            foreach(string num in nums)
            {
                sequences[0].Add(Convert.ToInt32(num));
            }
            while (!sequences[index-1].All(x=>x==0))
            {
                sequences.Add(new List<int>());
                for(int i = 0; i < sequences[index-1].Count-1; i++)
                {
                    sequences[index].Add(sequences[index - 1][i + 1] - sequences[index - 1][i]);
                }
                index++;
            }
            index--;
            sequences[index].Add(0);
            while(index>0)
            {
                index--;
                sequences[index].Add(sequences[index + 1][sequences[index + 1].Count - 1] + sequences[index][sequences[index].Count-1]);
            }
            sum += sequences[0][sequences[0].Count - 1];
        }

        Console.WriteLine(sum);
    }
    static void PartTwo()
    {
        int sum = 0;
        foreach (string line in input)
        {
            int index = 1;
            string[] nums = line.Split(" ");
            List<List<int>> sequences = new List<List<int>>();
            sequences.Add(new List<int>());
            foreach (string num in nums)
            {
                sequences[0].Add(Convert.ToInt32(num));
            }
            while (!sequences[index - 1].All(x => x == 0))
            {
                sequences.Add(new List<int>());
                for (int i = 0; i < sequences[index - 1].Count - 1; i++)
                {
                    sequences[index].Add(sequences[index - 1][i + 1] - sequences[index - 1][i]);
                }
                index++;
            }
            index--;
            sequences[index].Insert(0, 0);
            while (index > 0)
            {
                index--;
                sequences[index].Insert(0, sequences[index][0] - sequences[index + 1][0]);
            }
            //Console.WriteLine(sequences[0][0]);
            sum += sequences[0][0];
        }

        Console.WriteLine(sum);
    }
}