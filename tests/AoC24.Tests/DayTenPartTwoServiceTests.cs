using Days.Ten;
using Xunit;

namespace AoE24.Tests;

public class DayTenPartTwoServiceTests
{
    [Fact]
    public void GetTrailheadRatings_WithCorrectInput_ReturnCorrectTrailheadRatings()
    {
        // Arrange
        var input = new List<string>
        {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732"
        };

        //Act
        var result = DayTenPartTwoService.GetTrailheadRatings(input);

        // Assert
        Assert.Equal(81, result);
    }
}