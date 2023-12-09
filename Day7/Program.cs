class Day7
{
    //static string[] input = File.ReadAllLines("../../../testInput.txt");
    static string[] input = File.ReadAllLines("../../../input.txt");
    static List<Hand> hands = new List<Hand>();
    public static Dictionary<char, int> cardValues = new Dictionary<char, int>() {
        { 'A', 14}, { 'K', 13}, { 'Q', 12 }, { 'J', 11 }, { 'T', 10 }, { '9', 9 }, { '8', 8}, { '7', 7},{ '6', 6}, { '5', 5},{ '4', 4}, { '3', 3},{'2', 2}
    };
    public static void Main()
    {
        PartOne();
        cardValues['J'] = 1;
        hands.Clear();
        PartTwo();
    }
    static void PartOne()
    {
        int totalWinning = 0;
        foreach(var line in input)
        {
            hands.Add(new Hand(line, false));
        }
        hands.Sort(CompareHands);
        for(int i = 0; i < hands.Count; i++)
        {
            totalWinning += hands[i].bid * (i + 1);
        }
        Console.WriteLine(totalWinning);
    }
    static void PartTwo()
    {
        int totalWinning = 0;
        foreach (var line in input)
        {
            hands.Add(new Hand(line, true));
        }
        hands.Sort(CompareHands);
        for (int i = 0; i < hands.Count; i++)
        {
            totalWinning += hands[i].bid * (i + 1);
        }
        Console.WriteLine(totalWinning);
    }
    static int CompareHands(Hand hand1, Hand hand2)
    {
        if(hand1.value == hand2.value)
        {
            for(int i = 0; i < 5; i++)
            {
                if (hand1.originalCards[i]!=hand2.originalCards[i])
                    return cardValues[hand1.originalCards[i]].CompareTo(cardValues[hand2.originalCards[i]]);
            }
        }
        return hand1.value.CompareTo(hand2.value);
    }
}
class Hand
{
    public string cards;
    public string originalCards;
    public int bid;
    public int value;
    public Hand(string input, bool jokers)
    {
        cards = input.Split(" ")[0];
        originalCards = cards;
        bid = Convert.ToInt32(input.Split(" ")[1]);
        if (jokers)
            cards = ChangeJokers();
        value = CalculateValue();
    }
    int CalculateValue()
    {
        if (cards.Distinct().Count() == 1)
            return 6;
        else if (cards.GroupBy(x => x).Any(x => x.Count() == 4))
            return 5;
        else if (cards.GroupBy(x => x).Any(x => x.Count() == 3) && cards.Distinct().Count() == 2)
            return 4;
        else if (cards.GroupBy(x => x).Any(x => x.Count() == 3))
            return 3;
        else if (cards.GroupBy(x => x).Where(x => x.Count() == 2).Count() == 2)
            return 2;
        else if (cards.GroupBy(x => x).Any(x => x.Count() == 2))
            return 1;
        return 0;
    }
    string ChangeJokers()
    {
        char c = cards.Where(x => x !='J').GroupBy(x => x).OrderByDescending(x => x.Count()).ThenByDescending(x => Day7.cardValues[x.Key]).FirstOrDefault()?.Key ?? default(char);
        string result = "";
        for(int i = 0; i < 5; i++)
        {
            if (c == 0)
                result += 'A';
            else if (cards[i] == 'J')
                result += c;
            else
                result += cards[i];
        }
        return result;
    }
}