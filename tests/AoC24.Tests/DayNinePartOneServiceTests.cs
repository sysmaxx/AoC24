using Days.Nine;
using Xunit;

namespace AoE24.Tests;

public class DayNinePartOneServiceTests
{
    [Fact]
    public void GetFileSystemCheckSum_WhenCalled_ReturnsCorrectCheckSum()
    {
        // Arrange
        var inputData = new List<string>
        {
            "2333133121414131402"
        };

        // Act
        var result = DayNinePartOneService.GetFileSystemCheckSum(inputData);

        // Assert
        Assert.Equal(1928, result);
    }
}