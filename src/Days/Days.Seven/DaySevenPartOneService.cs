namespace Days.Seven;

/// <summary>
/// Contains logic for solving the equations in Day 7 Part 1.
/// </summary>
public static class DaySevenPartOneService
{
    /// <summary>
    /// Calculates the sum of test values from equations that can be solved with any combination of operators (+, *).
    /// </summary>
    public static long CalculateTotalCalibrationResult(IEnumerable<string> input)
    {
        var parsedInput = ParseInput(input);

        return parsedInput
            .Where(line => CanAchieveTargetValue(line.Item2, line.Item1))
            .Sum(line => line.Item1);
    }

    private static IEnumerable<(long, long[])> ParseInput(IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            var parts = line.Split(':');
            if (parts.Length != 2) continue;

            var targetValue = long.Parse(parts[0].Trim());
            var numbers = Array.ConvertAll(parts[1].Trim().Split(' '), long.Parse);

            yield return (targetValue, numbers);
        }
    }

    private static bool CanAchieveTargetValue(long[] numbers, long targetValue)
    {
        return EvaluateOperators(numbers, 1, numbers[0], targetValue);
    }

    private static bool EvaluateOperators(long[] numbers, int index, long currentValue, long targetValue)
    {
        if (index == numbers.Length)
        {
            return currentValue == targetValue;
        }

        // Try adding the next number
        if (EvaluateOperators(numbers, index + 1, currentValue + numbers[index], targetValue))
        {
            return true;
        }

        // Try multiplying the next number
        if (EvaluateOperators(numbers, index + 1, currentValue * numbers[index], targetValue))
        {
            return true;
        }

        return false;
    }
}