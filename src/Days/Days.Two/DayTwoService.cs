namespace Days.Two;

/// <summary>
/// This class contains the logic for day two.
/// </summary>
public static class DayTwoService
{
    /// <summary>
    /// Get the number of safety levels.
    /// </summary>
    public static int GetNumberOfSafetyLevels(IEnumerable<string> inputData)
        => inputData.Select(GetRowValues).Sum(row => IsSafe(row) ? 1 : 0);

    /// <summary>
    /// Get the number of safety levels with dampener.
    /// </summary>
    public static int GetNumberOfSafetyLevelsWithDampener(IEnumerable<string> inputData)
        => inputData.Select(GetRowValues).Sum(row => IsSafeWithDampener(row) ? 1 : 0);

    internal static bool IsSafe(int[] levels)
    {
        if (levels.Length < 2)
            return false; // A valid report needs at least two levels to compare.

        var isIncreasing = levels[1] > levels[0];
        var isDecreasing = levels[1] < levels[0];

        for (var i = 1; i < levels.Length; i++)
        {
            var diff = levels[i] - levels[i - 1];

            // Check if difference is within the allowed range
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            // Check if direction is consistent
            if (isIncreasing && diff <= 0)
                return false;
            if (isDecreasing && diff >= 0)
                return false;
        }

        return true;
    }

    internal static bool IsSafeWithDampener(int[] levels)
    {
        // First, check if the report is already safe without the dampener.
        if (IsSafe(levels))
            return true;

        // Try removing each level and check if the modified report is safe.
        for (var i = 0; i < levels.Length; i++)
        {
            var modifiedLevels = RemoveLevel(levels, i);
            if (IsSafe(modifiedLevels))
                return true;
        }

        return false; // Unsafe even with the dampener.
    }

    private static int[] RemoveLevel(int[] levels, int indexToRemove)
    {
        var modifiedLevels = new List<int>(levels.Length - 1);

        for (int i = 0; i < levels.Length; i++)
        {
            if (i != indexToRemove)
                modifiedLevels.Add(levels[i]);
        }

        return modifiedLevels.ToArray();
    }

    private static int[] GetRowValues(string input)
    {
        const char separator = ' ';

        return input.Split(separator)
            .Select(int.Parse)
            .ToArray();
    }
}