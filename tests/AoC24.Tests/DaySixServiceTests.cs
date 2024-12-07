using System.Collections.ObjectModel;
using Days.Six;
using Xunit;

namespace AoE24.Tests;

public class DaySixServiceTests
{
    [Fact]
    public void GetTotalUniqueVisitedPositions_WithCorrectInput_CalculateDistinctPositions()
    {
        // Arrange
        var input = new Collection<string>()
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#...",
        };

        //Act
        var result = DaySixService.GetTotalUniqueVisitedPositions(input);

        // Assert
        Assert.Equal(41, result);
    }
}