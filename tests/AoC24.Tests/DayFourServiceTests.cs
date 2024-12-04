using Days.Four;
using Xunit;

namespace AoE24.Tests;

public class DayFourServiceTests
{
    [Fact]
    public void CountXmasWord_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        var inputData = new List<string>
        {
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
        };

        // Act
        var result = DayFourService.CountXmasWord(inputData);

        // Assert
        Assert.Equal(18, result);
    }
    
    [Fact]
    public void CountXmasWordInShape_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        var inputData = new List<string>
        {
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
        };

        // Act
        var result = DayFourService.CountXmasWordInShape(inputData);

        // Assert
        Assert.Equal(9, result);
    }

    private static string v = @"

.M.S......
..A..MSMS.
.M.S.MAA..
..A.ASMSM.
.M.S.M....
..........
S.S.S.S.S.
.A.A.A.A..
M.M.M.M.M.
..........

";
}