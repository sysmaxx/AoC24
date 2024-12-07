namespace Days.Six;

/// <summary>
/// Contains the logic for solving the sixth day puzzle.
/// </summary>
public static class DaySixService
{
    public static int GetTotalUniqueVisitedPositions(IEnumerable<string> mapInput)
    {
        var map = mapInput.Select(line => line.ToCharArray()).ToArray();
        var visited = GetSimulateGuardPath(map);
        return visited.Count;
    }

    // Directions: Up, Right, Down, Left (in clockwise order)
    private static readonly (int dx, int dy)[] Directions =
    {
        (-1, 0), // Up
        (0, 1), // Right
        (1, 0), // Down
        (0, -1) // Left
    };

    private static HashSet<(int, int)> GetSimulateGuardPath(char[][] map)
    {
        var numRows = map.Length;
        var numCols = map[0].Length;

        // Find the guard's starting position and direction
        int guardX = -1, guardY = -1, directionIndex = -1;
        for (var row = 0; row < numRows; row++)
        {
            for (var col = 0; col < numCols; col++)
            {
                var cell = map[row][col];
                if (cell != '^')
                    continue;

                guardX = row;
                guardY = col;
                directionIndex = "^>v<".IndexOf(cell);
                break;
            }
        }

        // Track visited positions and states
        var visitedStates = new HashSet<(int x, int y, int direction)> { (guardX, guardY, directionIndex) };

        // Simulate guard movement
        while (true)
        {
            var (dx, dy) = Directions[directionIndex];
            var nextX = guardX + dx;
            var nextY = guardY + dy;

            if (nextX < 0 || nextX >= numRows || nextY < 0 || nextY >= numCols)
            {
                // Guard has left the map
                break;
            }

            if (map[nextX][nextY] == '#')
            {
                // Obstacle in front; turn right
                directionIndex = (directionIndex + 1) % 4;
            }
            else
            {
                // Move forward
                guardX = nextX;
                guardY = nextY;

                visitedStates.Add((guardX, guardY, directionIndex));
            }
        }

        return visitedStates.Select(state => (state.x, state.y)).ToHashSet();
    }
}