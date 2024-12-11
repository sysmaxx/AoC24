using Days.Eleven;
using Xunit;

namespace AoE24.Tests;

public class DayElevenPartOneServiceTests
{
    [Fact]
    public void GetStoneCount_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        const string inputData = "125 17";

        // Act
        var result = DayElevenPartOneService.GetStoneCount(inputData);

        // Assert
        Assert.Equal(55312, result);
    }
}