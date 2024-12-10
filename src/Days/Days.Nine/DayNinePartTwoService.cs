using System.Text.RegularExpressions;

namespace Days.Nine;

public static class DayNinePartTwoService
{
    public static long GetFileSystemCheckSum(IEnumerable<string> inputData)
    {
        var checkSums = (DayNinePartOneService.GetNumbers(inputData)
            .Select(DayNinePartOneService.GenerateDataFragment)
            .Select(DayNinePartTwoService.DefragmentString)
            .Select(DayNinePartOneService.GetCheckSum)).ToList();


        return checkSums.Sum();
    }

    public static char[] DefragmentString(IEnumerable<char> dataFragment)
    {
        var stringData = string.Join("", dataFragment);

        var blocks = FindBlocks(stringData).Where(x => x.Char != '.').ToList();

        for (var i = blocks.Count - 1; i >= 0; i--)
        {
            var indexOfSpace = stringData.IndexOf(new string('.', blocks[i].Length), StringComparison.Ordinal);
            if (indexOfSpace == -1 || indexOfSpace >= blocks[i].Index)
                continue;
            stringData = stringData.Remove(indexOfSpace, blocks[i].Length);
            stringData = stringData.Insert(indexOfSpace, new string(blocks[i].Char, blocks[i].Length));
            stringData = stringData.Remove(blocks[i].Index, blocks[i].Length);
            stringData = stringData.Insert(blocks[i].Index, new string('.', blocks[i].Length));
        }

        return stringData.ToCharArray();
    }

    public static IEnumerable<(int Index, int Length, char Char)> FindBlocks(string input)
    {
        var blocks = new List<(int Index, int Length)>();

        if (string.IsNullOrEmpty(input))
            yield break;

        var start = 0;
        var currentChar = input[0];

        for (var i = 1; i <= input.Length; i++)
        {
            if (i != input.Length && input[i] == currentChar)
                continue;

            yield return (start, i - start, currentChar);

            if (i >= input.Length)
                continue;

            start = i;
            currentChar = input[i];
        }
    }
}