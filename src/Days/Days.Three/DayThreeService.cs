using System.Text.RegularExpressions;

namespace Days.Three;

/// <summary>
/// This class contains the logic for day three.
/// </summary>
public class DayThreeService
{
    /// <summary>
    /// Get the sum of all valid multiplications in the input data.
    /// </summary>
    public static int GetSumOfCorruptedInput(IEnumerable<string> inputData)
    {
        return inputData.Sum(SumValidMultiplications);
    }

    /// <summary>
    /// Get the sum of all valid multiplications in the input data, with control instructions.
    /// </summary>
    public static int GetSumOfCorruptedInputWithControl(IEnumerable<string> inputData)
    {
        var combinedInput = string.Join("", inputData);

        return SumValidMultiplicationsWithControl(combinedInput);
    }

    private static int SumValidMultiplications(string inputRow)
    {
        const string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        var matches = Regex.Matches(inputRow, pattern);

        var sum = 0;

        foreach (Match match in matches)
        {
            if (!match.Success)
                continue;
            
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            
            sum += x * y;
        }

        return sum;
    }

    private static int SumValidMultiplicationsWithControl(string input)
    {
        const string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        const string controlPattern = @"do\(\)|don't\(\)";
        const string doControl = "do()";
        const string dontControl = "don't()";

        var matches = Regex.Matches(input, $@"{mulPattern}|{controlPattern}");

        var sum = 0;
        var controlEnabled = true;

        foreach (Match match in matches)
        {
            if (Regex.IsMatch(match.Value, controlPattern))
            {
                // Handle control instructions
                if (match.Value == doControl)
                {
                    controlEnabled = true;
                }
                else if (match.Value == dontControl)
                {
                    controlEnabled = false;
                }
            }
            else if (controlEnabled && Regex.IsMatch(match.Value, mulPattern))
            {
                // Handle multiplication instructions
                var mulMatch = Regex.Match(match.Value, mulPattern);
                if (mulMatch.Success)
                {
                    var x = int.Parse(mulMatch.Groups[1].Value);
                    var y = int.Parse(mulMatch.Groups[2].Value);

                    sum += x * y;
                }
            }
        }

        return sum;
    }
}