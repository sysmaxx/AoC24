using System.Text.RegularExpressions;

namespace Days.Example;

/// <summary>
/// This class contains the logic for the first day of the Advent of Code 2023.
/// Puzzle: https://adventofcode.com/2023/day/1#part2
/// </summary>
public static class DayExampleService
{
    public static int GetSummarizedCalibrationValues(IEnumerable<string> calibrationValues)
    {
        return calibrationValues
            .Select(ReplaceOverlaps)
            .Select(ReplaceSpelledDigits)
            .Select(GetDigits)
            .Sum(x => Convert.ToInt16($"{x[0]}{x[^1]}"));
    }

    internal static char[] GetDigits(string calibrationValues) => calibrationValues.Where(char.IsDigit).ToArray();

    internal static string ReplaceOverlaps(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        
        var overlaps = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "oneight", "oneeight" },
            { "threeight", "threeeight" },
            { "fiveight", "fiveeight" },
            { "nineight", "nineeight" },
            { "twone", "twoone" },
            { "sevenine", "sevennine" },
            { "eightwo", "eighttwo" },
        };

        // Build a Regex pattern for all number words
        string pattern = string.Join("|", overlaps.Keys);

        // Use Regex.Replace with a match evaluator for replacements
        string result = Regex.Replace(input, pattern, match => overlaps[match.Value], RegexOptions.IgnoreCase);

        return result;
    }
    
    internal static string ReplaceSpelledDigits(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // Mapping spelled-out numbers to digits
        var numberMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };

        // Build a Regex pattern for all number words
        string pattern = string.Join("|", numberMap.Keys);

        // Use Regex.Replace with a match evaluator for replacements
        string result = Regex.Replace(input, pattern, match => numberMap[match.Value], RegexOptions.IgnoreCase);

        return result;
    }
}