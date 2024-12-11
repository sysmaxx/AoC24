namespace Days.Eleven;

public static class DayElevenPartOneService
{
    public static long GetStoneCount(string inputData, long blinksCount = 25)
    {
        var stoneCounts = new Dictionary<long, long>();

        // Initialize stone counts
        foreach (var stone in inputData.Split(' ').Select(long.Parse))
        {
            if (stoneCounts.ContainsKey(stone))
                stoneCounts[stone]++;
            else
                stoneCounts[stone] = 1;
        }

        for (var i = 0; i < blinksCount; i++)
        {
            var newStoneCounts = new Dictionary<long, long>();

            foreach (var (stone, count) in stoneCounts)
            {
                if (stone == 0)
                {
                    // Rule 1: Replace 0 with 1
                    AddToDictionary(newStoneCounts, 1, count);
                }
                else if (CountDigits(stone) % 2 == 0)
                {
                    // Rule 2: Split even-digit numbers
                    var (left, right) = SplitStone(stone);
                    AddToDictionary(newStoneCounts, left, count);
                    AddToDictionary(newStoneCounts, right, count);
                }
                else
                {
                    // Rule 3: Multiply odd-digit numbers by 2024
                    AddToDictionary(newStoneCounts, stone * 2024, count);
                }
            }

            stoneCounts = newStoneCounts;
        }

        // Total number of stones is the sum of all counts
        return stoneCounts.Values.Sum();
    }

    private static void AddToDictionary(Dictionary<long, long> dict, long key, long count)
    {
        if (dict.ContainsKey(key))
            dict[key] += count;
        else
            dict[key] = count;
    }

    private static int CountDigits(long number)
    {
        return number == 0 ? 1 : (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
    }

    private static (long, long) SplitStone(long stone)
    {
        var digits = CountDigits(stone);
        var divisor = (long)Math.Pow(10, digits / 2);
        return (stone / divisor, stone % divisor);
    }
}
