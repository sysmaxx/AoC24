namespace Days.Nine;

public static class DayNinePartOneService
{
    public static long GetFileSystemCheckSum(IEnumerable<string> inputData)
    {
        var checkSums = (GetNumbers(inputData)
            .Select(GenerateDataFragment)
            .Select(DefragmentData)
            .Select(GetCheckSum)).ToList();

        return checkSums.Sum();
    }

    internal static List<char> GenerateDataFragment(int[] line)
    {
        var dataFragment = new List<char>();
        var dataIndex = 0;

        for (var i = 0; i < line.Length; i++)
        {
            for (var j = 0; j < line[i]; j++)
            {
                if (i % 2 == 0)
                {
                    dataFragment.Add((char)(dataIndex + '0'));
                }
                else
                {
                    dataFragment.Add('.');
                }
            }

            if (i % 2 == 0)
            {
                dataIndex++;
            }
        }

        return dataFragment;
    }

    internal static long GetCheckSum(IEnumerable<char> defragmentedData)
    {
        var result = 0L;

        foreach (var (data, i) in defragmentedData.Select((x, i) => (x, i)))
        {
            if(data == '.')
                continue;
            
            
            result += (data - '0') * i;
        }

        return result;
    }

    internal static IEnumerable<char> DefragmentData(List<char> dataFragment)
    {
        for (var i = dataFragment.Count() - 1; i >= 0; i--)
        {
            var data = dataFragment[i];

            if (data == '.')
                continue;

            // find first '.' and replace it with data
            var firstDotIndex = dataFragment.IndexOf('.');

            if (firstDotIndex == -1)
            {
                break;
            }

            dataFragment[firstDotIndex] = data;
            dataFragment[i] = '.';
        }

        return dataFragment.Where(x => x != '.');
    }

    internal static IEnumerable<int[]> GetNumbers(IEnumerable<string> rows)
    {
        return rows.Select(line => line.ToArray().Select(x => int.Parse(x.ToString())).ToArray());
    }
}