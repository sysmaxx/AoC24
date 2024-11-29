namespace Days.One;

public static class DayOneService
{
    public static int GetSummarizedCalibrationValues(IReadOnlyCollection<string> calibrationValues)
    {
        return calibrationValues
            .Select(GetDigits)
            .Sum(x => Convert.ToInt16($"{x[0]}{x[^1]}"));
    }

    internal static char[] GetDigits(string calibrationValues) => calibrationValues.Where(char.IsDigit).ToArray();
}