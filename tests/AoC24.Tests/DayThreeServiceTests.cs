using Days.Three;
using Xunit;

namespace AoE24.Tests;

public class DayThreeServiceTests
{
    [Fact]
    public void GetSumOfCorruptedInput_WhenCalled_ReturnsExpectedSum()
    {
        // Arrange
        var inputData = new List<string>
        {
            "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))",
        };

        // Act
        var result = DayThreeService.GetSumOfCorruptedInput(inputData);

        // Assert
        Assert.Equal(161, result);
    }
    
    [Fact]
    public void GetSumOfCorruptedInputWithControl_WhenCalled_ReturnsExpectedSum()
    {
        // Arrange
        var inputData = new List<string>
        {
            "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",
        };

        // Act
        var result = DayThreeService.GetSumOfCorruptedInputWithControl(inputData);

        // Assert
        Assert.Equal(48, result);
    }
}