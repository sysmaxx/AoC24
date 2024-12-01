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
            int.TryParse(firstColumnDistances[i], out var firstPoint);
            int.TryParse(secondColumnDistances[i], out var secondPoint);

            totalDistance += Math.Abs(firstPoint - secondPoint);
        }

        return totalDistance;
    }

    /// <summary>
    /// Part 2 of the puzzle
    /// </summary>
    public static int GetMultipliedSummarizedDistance(IEnumerable<string> inputData)
    {
        var distanceList = inputData.Select(GetValuePairs).ToArray();

        // Group the second column distances and count occurrences
        var secondColumnCounts = distanceList
            .GroupBy(x => x.Item2)
            .ToDictionary(g => g.Key, g => g.Count());

        // Calculate the total distance using the grouped counts
        var totalDistance = distanceList
            .Select(x => (First: int.TryParse(x.Item1, out var value) ? value : 0, Count: secondColumnCounts.GetValueOrDefault(x.Item1, 0)))
            .Sum(pair => pair.First * pair.Count);

        return totalDistance;
    }

    /// <summary>
    /// Split the input into two values
    /// </summary>
    internal static (string, string) GetValuePairs(string input)
    {
        const string separator = "   ";

        if (string.IsNullOrWhiteSpace(input) || input.Contains(separator) == false)
        {
            throw new ArgumentException("Input does not in correct format", nameof(input));
        }

        var split = input.Split(separator);
        return (split[0], split[1]);
    }
}