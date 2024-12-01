namespace Days.One;

/// <summary>
/// This class contains the logic for the first day of the Advent of Code 2024.
/// https://adventofcode.com/2024/day/1#part2
/// </summary>
public static class DayOneService
{
    public static int GetSummarizedDistance(IEnumerable<string> inputDate)
    {
        var distanceList = inputDate.Select(GetListValuePairs).ToArray();
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

    internal static (string, string) GetListValuePairs(string input)
    {
        var split = input.Split("   ");
        return (split[0], split[1]);
    }
}