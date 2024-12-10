namespace Days.Ten;

public static class DayTenPartOneService
{
    public static int GetTrailheadScores(IEnumerable<string> input)
    {
        var map = GetMap(input);
        var trailheads = FindTrailheads(map);
        var totalScore = 0;

        foreach (var trailhead in trailheads)
        {
            var reachableNines = new HashSet<Point>();
            GetPaths(map, trailhead, [], reachableNines);
            totalScore += reachableNines.Count;
        }

        return totalScore;
    }

    internal static HashSet<Point> FindTrailheads(int[][] map)
    {
        var trailheads = new HashSet<Point>();
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == 0) trailheads.Add(new Point(x, y));
            }
        }

        return trailheads;
    }

    internal static void GetPaths(int[][] map, Point position, List<Point> path, HashSet<Point> reachableNines)
    {
        if (path.Contains(position))
            return;

        // Create a new path instance for recursion
        path = [..path, position];

        if (map[position.Y][position.X] == 9)
        {
            reachableNines.Add(position);
            return;
        }

        var possibleMoves = GetPossibleMoves(map, position);
        foreach (var move in possibleMoves)
        {
            GetPaths(map, move, path, reachableNines);
        }
    }

    internal static HashSet<Point> GetPossibleMoves(int[][] map, Point position)
    {
        var moves = new HashSet<Point>();
        var x = position.X;
        var y = position.Y;
        var currentValue = map[y][x];

        var directions = new List<Point>
        {
            new Point(x - 1, y), // Left
            new Point(x + 1, y), // Right
            new Point(x, y - 1), // Up
            new Point(x, y + 1) // Down
        };

        foreach (var direction in directions)
        {
            if (IsInBounds(map, direction) && map[direction.Y][direction.X] == currentValue + 1)
            {
                moves.Add(direction);
            }
        }

        return moves;
    }

    internal static bool IsInBounds(int[][] map, Point position)
    {
        return position.X >= 0 && position.X < map[0].Length && position.Y >= 0 && position.Y < map.Length;
    }

    internal static int[][] GetMap(IEnumerable<string> input)
    {
        return input
            .Select(line => line.Select(c => c - '0').ToArray())
            .ToArray();
    }
}

public record struct Point(int X, int Y);