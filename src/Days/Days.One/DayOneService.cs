namespace Days.One;

/// <summary>
/// This class contains the logic for the first day of the Advent of Code 2024.
/// https://adventofcode.com/2024/day/1#part2
/// </summary>
public static class DayOneService
{
    /// <summary>
    /// Part 1 of the puzzle
    /// </summary>
    public static int GetSummarizedDistance(IEnumerable<string> inputDate)
    {
        var distanceList = inputDate.Select(GetValuePairs).ToArray();
        var firstColumnDistances = distanceList.Select(x => x.Item1).Order().ToList();
        var secondColumnDistances = distanceList.Select(x => x.Item2).Order().ToList();

        var totalDistance = 0;

        // Pair up the numbers and calculate the distances
        for (int i = 0; i < firstColumnDistances.Count; i++)
        {

            totalDistance += Math.Abs(firstColumnDistances[i] - secondColumnDistances[i]);
        }

        return totalDistance;
    }

    /// <summary>
    /// Part 2 of the puzzle
    /// </summary>
    public static int GetMultipliedSummarizedDistance(IEnumerable<string> inputDate)
    {
        var distanceList = inputDate.Select(GetValuePairs).ToArray();
        var firstColumnDistances = distanceList.Select(x => x.Item1).Order();

        var duplicatesCount = distanceList.Select(x => x.Item2)
                                .GroupBy(n => n)
                                .ToDictionary(g => g.Key, g => g.Count());
                                
        var totalDistance = 0;

        foreach (var firstColumn in firstColumnDistances)
        {

            var secondColumnCount = duplicatesCount.TryGetValue(firstColumn, out int t2) ? t2 : 0;

            totalDistance += firstColumn * secondColumnCount;
        }

        return totalDistance;
    }

    /// <summary>
    /// Split the input into two values
    /// </summary>
    internal static (int, int) GetValuePairs(string input)
    {
        const string separator = "   ";

        if (string.IsNullOrWhiteSpace(input) || input.Contains(separator) == false)
        {
            throw new ArgumentException("Input does not in correct format", nameof(input));
        }

        var split = input.Split(separator);
        return (Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
    }
}