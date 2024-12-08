using Days.Eight;
using Xunit;

namespace AoE24.Tests;

public class DayEightPartTwoServiceTests
{
    [Fact]
    public void CountAntinodes_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        var inputData = new List<string>
        {
            "T.........",
            "...T......",
            ".T........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
        };

        // Act
        var result = DayEightPartTwoService.CountAntinodes(inputData);

        // Assert
        Assert.Equal(9, result);
    }
}