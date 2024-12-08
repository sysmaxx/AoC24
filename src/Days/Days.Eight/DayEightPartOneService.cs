namespace Days.Eight;

/// <summary>
/// Contains the logic for Day 8 Part 1 puzzle.
/// </summary>
public static class DayEightPartOneService
{
    public static int CountAntinodes(IEnumerable<string> input)
    {
        var map = GetMap(input);
        var antennaPositions = GetAntennaPosition(map);
        var antinodes = new HashSet<(int X, int Y)>();

        foreach (var antenna in antennaPositions)
        {
            var positions = antenna.Value.ToArray();
            for (var i = 0; i < positions.Length; i++)
            {
                for (var j = i + 1; j < positions.Length; j++)
                {
                    var (newPoint1, newPoint2) = GetExtendedPoints(positions[i], positions[j]);

                    if (IsInBounds(map, newPoint1.X, newPoint1.Y))
                        antinodes.Add(newPoint1);

                    if (IsInBounds(map, newPoint2.X, newPoint2.Y))
                        antinodes.Add(newPoint2);
                }
            }
        }

        return antinodes.Count;
    }

    private static IReadOnlyDictionary<char, IEnumerable<(int X, int Y)>> GetAntennaPosition(char[][] map)
    {
        var antennaPositions = new Dictionary<char, IEnumerable<(int X, int Y)>>();

        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '.')
                    continue;

                var antenna = map[y][x];
                if (!antennaPositions.ContainsKey(antenna))
                    antennaPositions[antenna] = new List<(int X, int Y)>();

                ((List<(int X, int Y)>)antennaPositions[antenna]).Add((x, y));
            }
        }

        return antennaPositions;
    }

    private static ((int X, int Y) newPoint1, (int X, int Y) newPoint2)
        GetExtendedPoints((int X, int Y) point1, (int X, int Y) point2)
    {
        // Calculate the difference in x and y coordinates
        var dx = point2.X - point1.X;
        var dy = point2.Y - point1.Y;

        // Extend the points by adding and subtracting the differences
        var newPoint1 = (X: point1.X - dx, Y: point1.Y - dy);
        var newPoint2 = (X: point2.X + dx, Y: point2.Y + dy);

        return (newPoint1, newPoint2);
    }

    private static bool IsInBounds(char[][] map, int x, int y)
    {
        return x >= 0 && x < map[0].Length && y >= 0 && y < map.Length;
    }

    private static char[][] GetMap(IEnumerable<string> input)
    {
        return input
            .Select(x => x.ToCharArray())
            .ToArray();
    }
}