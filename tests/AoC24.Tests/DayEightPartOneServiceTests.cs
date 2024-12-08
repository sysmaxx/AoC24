using Days.Eight;
using Xunit;

namespace AoE24.Tests;

public class DayEightPartOneServiceTests
{
    [Fact]
    public void CountAntinodes_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        var inputData = new List<string>
        {
            "..........",
            "..........",
            "..........",
            "....a.....",
            "........a.",
            ".....a....",
            "..........",
            "..........",
            "..........",
            "..........",
        };

        // Act
        var result = DayEightPartOneService.CountAntinodes(inputData);

        // Assert
        Assert.Equal(4, result);
    }
    
    [Fact]
    public void CountAntinodesWithTwoAntennas_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        var inputData = new List<string>
        {
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............",
        };
        
        var inputData2 = new List<string>
        {
            "............",
            "...#....0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
        };

        // Act
        var result = DayEightPartOneService.CountAntinodes(inputData);

        // Assert
        Assert.Equal(14, result);
    }
}