namespace Days.Six;

/// <summary>
/// Contains the logic for solving the second part of the sixth day puzzle.
/// </summary>
public static class DaySixPartTwoService
{
    private static readonly Dictionary<char, (int dx, int dy)> Directions = new()
    {
        { '^', (-1, 0) },
        { 'v', (1, 0) },
        { '>', (0, 1) },
        { '<', (0, -1) }
    };

    public static int FindLoopObstructionCount(IEnumerable<string> gridInput)
    {
        var grid = gridInput.Select(row => row.ToList()).ToList();
        var rows = grid.Count;
        var cols = grid[0].Count;

        var start = FindStartPosition(grid, rows, cols);
        var (_, visited) = FindPath(grid, start, '^');
        var obstacles = visited.Where(v => v != start).ToHashSet();

        return obstacles.Count(obs => FindPath(grid, start, '^', obs).infiniteLoop);
    }

    private static (int x, int y) FindStartPosition(List<List<char>> grid, int rows, int cols)
    {
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == '^')
                {
                    return (i, j);
                }
            }
        }

        throw new InvalidOperationException("Guard starting position not found.");
    }

    private static (bool infiniteLoop, HashSet<(int x, int y)> visited) FindPath(List<List<char>> grid,
        (int x, int y) start, char dir, (int x, int y)? obs = null)
    {
        var (x, y) = start;
        var visited = new HashSet<(int x, int y)>();
        var posVectors = new HashSet<(int x, int y, char dir)>
        {
            (x, y, dir)
        };

        while (IsInBounds(grid, x, y))
        {
            visited.Add((x, y));
            var (dx, dy) = Directions[dir];
            int nx = x + dx, ny = y + dy;

            if (IsInBounds(grid, nx, ny) && (grid[nx][ny] == '#' || (obs.HasValue && (nx, ny) == obs.Value)))
            {
                dir = RotateRight(dir); // Turn right
            }
            else
            {
                x = nx;
                y = ny; // Move forward
            }

            var posVector = (x, y, dir);
            if (!posVectors.Add(posVector))
            {
                return (true, visited); // Infinite loop detected
            }
        }

        return (false, visited);
    }

    private static bool IsInBounds(List<List<char>> grid, int x, int y) =>
        x >= 0 && x < grid.Count && y >= 0 && y < grid[0].Count;

    private static char RotateRight(char dir)
    {
        return dir switch
        {
            '^' => '>',
            '>' => 'v',
            'v' => '<',
            '<' => '^',
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}