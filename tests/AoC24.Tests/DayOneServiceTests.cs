using System.Collections.ObjectModel;
using Days.One;
using Xunit;

namespace AoE24.Tests;

public class DayOneServiceTests
{
    [Fact]
    public void GetSummarizedDistance_WithCorrectInput_ExtractSummarizedDistance()
    {
        // Arrange
        var input = new Collection<string>()
        {
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"
        };

        //Act
        var result = DayOneService.GetSummarizedDistance(input);

        // Assert
        Assert.Equal(11, result);
    }
    
    [Fact]
    public void GetMultipliedSummarizedDistance_WithCorrectInput_ExtractSummarizedDistance()
    {
        // Arrange
        var input = new Collection<string>()
        {
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3"
        };

        //Act
        var result = DayOneService.GetMultipliedSummarizedDistance(input);

        // Assert
        Assert.Equal(31, result);
    }
    
    [Theory]
    [InlineData("3   4", 3, 4)]
    [InlineData("10   20", 10, 20)]
    [InlineData("123   456", 123, 456)]
    public void GetValuePairs_ValidInput_ReturnsCorrectTuple(string input, int expectedLeft, int expectedRight)
    {
        // Act
        var result = DayOneService.GetValuePairs(input);

        // Assert
        Assert.Equal(expectedLeft, result.Item1);
        Assert.Equal(expectedRight, result.Item2);
    }
    
    [Theory]
    [InlineData("3 4")]
    [InlineData("a b")]
    [InlineData("3 4 5")]
    public void GetValuePairs_InvalidInput_ThrowsArgumentException(string input)
    {
        // Act
        void Act() => DayOneService.GetValuePairs(input);

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }
}