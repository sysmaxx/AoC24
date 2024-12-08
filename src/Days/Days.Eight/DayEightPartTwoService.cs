namespace Days.Eight
{
    public static class DayEightPartTwoService
    {
        public static int CountAntinodes(IEnumerable<string> input)
        {
            var map = GetMap(input);
            var antennaPositions = GetAntennaPositions(map);
            var antinodes = new HashSet<(int X, int Y)>();

            foreach (var frequency in antennaPositions.Keys)
            {
                var positions = antennaPositions[frequency].ToArray();

                // Mark all antennas as antinodes
                foreach (var position in positions)
                {
                    antinodes.Add(position);
                }

                // Calculate all antinodes along the alignment of antenna pairs
                for (var i = 0; i < positions.Length; i++)
                {
                    for (var j = i + 1; j < positions.Length; j++)
                    {
                        var alignedPoints = GetAlignedPoints(positions[i], positions[j], map);
                        foreach (var point in alignedPoints)
                        {
                            antinodes.Add(point);
                        }
                    }
                }
            }

            return antinodes.Count;
        }

        private static List<(int X, int Y)> GetAlignedPoints((int X, int Y) point1, (int X, int Y) point2, char[][] map)
        {
            var alignedPoints = new List<(int X, int Y)>();

            // Calculate the step differences for X and Y
            var dx = point2.X - point1.X;
            var dy = point2.Y - point1.Y;

            // Reduce dx and dy to their smallest integer ratio (directional vector)
            var gcd = GCD(Math.Abs(dx), Math.Abs(dy));
            dx /= gcd;
            dy /= gcd;

            // Extend in both directions
            var currentPoint = point1;
            while (IsInBounds(map, currentPoint.X, currentPoint.Y))
            {
                alignedPoints.Add(currentPoint);
                currentPoint = (currentPoint.X - dx, currentPoint.Y - dy);
            }

            currentPoint = point2;
            while (IsInBounds(map, currentPoint.X, currentPoint.Y))
            {
                alignedPoints.Add(currentPoint);
                currentPoint = (currentPoint.X + dx, currentPoint.Y + dy);
            }

            return alignedPoints;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static bool IsInBounds(char[][] map, int x, int y)
        {
            return x >= 0 && x < map[0].Length && y >= 0 && y < map.Length;
        }

        private static IReadOnlyDictionary<char, List<(int X, int Y)>> GetAntennaPositions(char[][] map)
        {
            var antennaPositions = new Dictionary<char, List<(int X, int Y)>>();

            for (var y = 0; y < map.Length; y++)
            {
                for (var x = 0; x < map[y].Length; x++)
                {
                    var cell = map[y][x];
                    if (cell == '.')
                        continue;

                    if (!antennaPositions.ContainsKey(cell))
                        antennaPositions[cell] = new List<(int X, int Y)>();

                    antennaPositions[cell].Add((x, y));
                }
            }

            return antennaPositions;
        }

        private static char[][] GetMap(IEnumerable<string> input)
        {
            return input
                .Select(x => x.ToCharArray())
                .ToArray();
        }
    }
}
