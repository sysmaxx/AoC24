using Days.Two;
using Xunit;

namespace AoE24.Tests;

public class DayTwoServiceTests
{
    [Fact]
    public void GetNumberOfSaftyLevels_WhenCalled_ReturnsExpectedCountOfSafetyLevers()
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
    public void GetNumberOfSafetyLevelsWithDumper_WhenCalled_ReturnsExpectedCountOfSafetyLevers()
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

    [Theory]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, false)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, false)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    public void IsSafe_WhenCalled_ReturnsExpected(int[] levels, bool expected)
    {
        // Act
        var result = DayTwoService.IsSafe(levels);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(new[] { 7, 6, 4, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 7, 8, 9 }, false)]
    [InlineData(new[] { 9, 7, 6, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, true)]
    [InlineData(new[] { 8, 6, 4, 4, 1 }, true)]
    [InlineData(new[] { 1, 3, 6, 7, 9 }, true)]
    public void IsSafeWithDampener_WhenCalled_ReturnsExpected(int[] levels, bool expected)
    {
        // Act
        var result = DayTwoService.IsSafeWithDampener(levels);

        // Assert
        Assert.Equal(expected, result);
    }
}