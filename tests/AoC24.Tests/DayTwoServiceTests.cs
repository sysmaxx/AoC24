using Days.Two;
using Xunit;

namespace AoE24.Tests;

public class DayTwoServiceTests
{
    [Fact]
    public void GetNumberOfSaftyLevels_WhenCalled_ReturnsZero()
    {
        // Arrange
        var inputData = new List<string>
        {
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        };

        // Act
        var result = DayTwoService.GetNumberOfSafetyLevels(inputData);

        // Assert
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void GetNumberOfSafetyLevelsWithDumper_WhenCalled_ReturnsZero()
    {
        // Arrange
        var inputData = new List<string>
        {
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        };

        // Act
        var result = DayTwoService.GetNumberOfSafetyLevelsWithDampener(inputData);

        // Assert
        Assert.Equal(4, result);
    }
}