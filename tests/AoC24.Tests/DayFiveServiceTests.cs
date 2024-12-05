using Days.Five;
using Days.Four;
using Xunit;

namespace AoE24.Tests;

public class DayFiveServiceTests
{
    [Fact]
    public void GetCount_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        var pageOrderingRules = new List<string>
        {
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13"
        };
        
        var pageUpdates = new List<string>
        {
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47",
        };

        // Act
        var result = DayFiveService.SumMiddlePages(pageOrderingRules, pageUpdates);

        // Assert
        Assert.Equal(143, result);
    }
    
    [Fact]
    public void GetCount2_WhenCalled_ReturnsExpectedCount()
    {
        // Arrange
        var pageOrderingRules = new List<string>
        {
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13"
        };
        
        var pageUpdates = new List<string>
        {
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47",
        };

        // Act
        var result = DayFiveService.SumSortedMiddlePages(pageOrderingRules, pageUpdates);

        // Assert
        Assert.Equal(123, result);
    }
}