namespace Days.Four;

/// <summary>
/// This class contains the logic for day four.
/// </summary>
public static class DayFourService
{
    private const string SearchWord = "XMAS";

    // Define the directions moving from the current position
    private static readonly int[][] Directions =
    [
        [0, 1], // Horizontal right
        [0, -1], // Horizontal left
        [1, 0], // Vertical down
        [-1, 0], // Vertical up
        [1, 1], // Diagonal down-right
        [1, -1], // Diagonal down-left
        [-1, 1], // Diagonal up-right
        [-1, -1] // Diagonal up-left
    ];

    public static int CountXmasWord(IEnumerable<string> inputData)
    {
        var grid = inputData.ToArray();

        var rows = grid.Length;
        var cols = grid[0].Length;
        var count = 0;

        // Check all positions in the grid
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                // Check all directions from the current position
                count += Directions.Count(dir => IsWordAtPosition(grid, SearchWord, row, col, dir[0], dir[1]));
            }
        }

        return count;
    }

    private static bool IsWordAtPosition(string[] grid, string word, int startRow, int startCol, int rowDelta,
        int colDelta)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        for (var i = 0; i < word.Length; i++)
        {
            var newRow = startRow + i * rowDelta;
            var newCol = startCol + i * colDelta;

            // Check if out of bounds
            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
            {
                return false;
            }

            // Check if the character matches
            if (grid[newRow][newCol] != word[i])
            {
                return false;
            }
        }

        return true;
    }

    public static int CountXmasWordInShape(IEnumerable<string> inputData)
    {
        var grid = inputData.ToArray();

        var rows = grid.Length;
        var cols = grid[0].Length;
        var count = 0;

        // Check all possible "X-MAS" shapes
        for (var row = 1; row < rows - 1; row++) // Avoid the grid edges
        {
            for (var col = 1; col < cols - 1; col++)
            {
                if (IsXmasShape(grid, row, col))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool IsXmasShape(string[] grid, int centerRow, int centerCol)
    {
        // Get the center point (A) and check the diagonal arms
        var center = grid[centerRow][centerCol];
        if (center != 'A')
            return false;

        var topLeftChar = grid[centerRow - 1][centerCol - 1];
        var bottomRightChar = grid[centerRow + 1][centerCol + 1];
        var topRightChar = grid[centerRow - 1][centerCol + 1];
        var bottomLeftChar = grid[centerRow + 1][centerCol - 1];

        return (topLeftChar == 'M' &&
                bottomLeftChar == 'M' &&
                topRightChar == 'S' &&
                bottomRightChar == 'S') ||
               (topLeftChar == 'S' &&
                bottomLeftChar == 'S' &&
                topRightChar == 'M' &&
                bottomRightChar == 'M') ||
               (topLeftChar == 'M' &&
                bottomLeftChar == 'S' &&
                topRightChar == 'M' &&
                bottomRightChar == 'S') ||
               (topLeftChar == 'S' &&
                bottomLeftChar == 'M' &&
                topRightChar == 'S' &&
                bottomRightChar == 'M');
    }
}