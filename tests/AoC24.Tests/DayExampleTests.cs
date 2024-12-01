using System.Collections.ObjectModel;
using Days.Example;
using Xunit;

namespace AoE24.Tests;

public class DayExampleTests
{
    [Fact]
    public void GetSummarizedCalibrationValues_WithCorrectInput_ExtractSummarizedCalibrationValues()
    {
        // Arrange
        var input = new Collection<string>()
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        
        //Act
        var result = DayExampleService.GetSummarizedCalibrationValues(input);
        
        // Assert
        Assert.Equal(142, result);
    }
    
    [Fact]
    public void GetSummarizedCalibrationValues_WithNewCorrectInput_ExtractSummarizedCalibrationValues()
    {
        // Arrange
        var input = new Collection<string>()
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        
        //Act
        var result = DayExampleService.GetSummarizedCalibrationValues(input);
        
        // Assert
        Assert.Equal(281, result);
    }
    
    [Theory]
    [InlineData("abc123def", new char[] { '1', '2', '3' })]
    [InlineData("456", new char[] { '4', '5', '6' })]
    [InlineData("no_digits_here", new char[] { })]
    [InlineData("a1b2c3", new char[] { '1', '2', '3' })]
    [InlineData("", new char[] { })] // Empty input
    [InlineData("1234567890", new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' })]
    public void GetDigits_ReturnsCorrectDigits(string input, char[] expected)
    {
        // Act
        var result = DayExampleService.GetDigits(input);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("one two three four five six seven eight nine zero", "1 2 3 4 5 6 7 8 9 0")]
    [InlineData("onehdbfjhsdbfzero", "1hdbfjhsdbf0")]
    public void ReplaceSpelledDigits_WithCorrectInput_ReplacesSpelledDigitsWithNumericDigits(string input, string expected)
    {
        // Act
        var result = DayExampleService.ReplaceSpelledDigits(input);

        // Assert
        Assert.Equal(expected, result);
    }
}