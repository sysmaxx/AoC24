namespace Days.Ten;

public static class DayTenPartTwoService
{
    public static int GetTrailheadRatings(IEnumerable<string> input)
    {
        var map = DayTenPartOneService.GetMap(input);
        var trailheads = DayTenPartOneService.FindTrailheads(map);
        return trailheads.Sum(trailhead => CalculateTrailheadRating(map, trailhead));
    }

    private static int CalculateTrailheadRating(int[][] map, Point trailhead)
    {
        var distinctTrails = new HashSet<List<Point>>(new PathEqualityComparer());
        ExplorePaths(map, trailhead, [], distinctTrails);
        return distinctTrails.Count;
    }

    private static void ExplorePaths(int[][] map, Point position, List<Point> currentPath,
        HashSet<List<Point>> distinctTrails)
    {
        if (currentPath.Contains(position)) return;

        // Create a new path including the current position
        currentPath = [..currentPath, position];

        if (map[position.Y][position.X] == 9)
        {
            distinctTrails.Add(currentPath);
            return;
        }

        var possibleMoves = DayTenPartOneService.GetPossibleMoves(map, position);
        foreach (var move in possibleMoves)
        {
            ExplorePaths(map, move, currentPath, distinctTrails);
        }
    }

    private class PathEqualityComparer : IEqualityComparer<List<Point>>
    {
        public bool Equals(List<Point> x, List<Point> y)
        {
            if (x == null || y == null || x.Count != y.Count) return false;

            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<Point> obj)
        {
            return obj.Aggregate(17, (hash, point) => hash * 31 + point.GetHashCode());
        }
    }
}
