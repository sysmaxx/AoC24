using Common.File;
using Common.Text;
using Days.Eight;
using Days.Five;
using Days.Four;
using Days.One;
using Days.Seven;
using Days.Six;
using Days.Three;
using Days.Two;

WelcomeWriter.WriteMessage();

ResultWriter<int>.WriteResult("1", "1", () => DayOneService
    .GetSummarizedDistance(FileUtilities.ReadLines("./Resources/inputDayOne.txt")));

ResultWriter<int>.WriteResult("1", "2", () => DayOneService
    .GetMultipliedSummarizedDistance(FileUtilities.ReadLines("./Resources/inputDayOne.txt")));

ResultWriter<int>.WriteResult("2", "1", () => DayTwoService
    .GetNumberOfSafetyLevels(FileUtilities.ReadLines("./Resources/inputDayTwo.txt")));

ResultWriter<int>.WriteResult("2", "2", () => DayTwoService
    .GetNumberOfSafetyLevelsWithDampener(FileUtilities.ReadLines("./Resources/inputDayTwo.txt")));

ResultWriter<int>.WriteResult("3", "1", () => DayThreeService
    .GetSumOfCorruptedInput(FileUtilities.ReadLines("./Resources/inputDayThree.txt")));

ResultWriter<int>.WriteResult("3", "2", () => DayThreeService
    .GetSumOfCorruptedInputWithControl(FileUtilities.ReadLines("./Resources/inputDayThree.txt")));

ResultWriter<int>.WriteResult("4", "1", () => DayFourService
    .CountXmasWord(FileUtilities.ReadLines("./Resources/inputDayFour.txt")));

ResultWriter<int>.WriteResult("4", "2", () => DayFourService
    .CountXmasWordInShape(FileUtilities.ReadLines("./Resources/inputDayFour.txt")));

ResultWriter<int>.WriteResult("5", "1", () => DayFiveService
    .SumMiddlePages(
        FileUtilities.ReadLines("./Resources/inputDayFivePageOrderingRules.txt"),
        FileUtilities.ReadLines("./Resources/inputDayFiveUpdatePages.txt")
    ));

ResultWriter<int>.WriteResult("5", "2", () => DayFiveService
    .SumSortedMiddlePages(
        FileUtilities.ReadLines("./Resources/inputDayFivePageOrderingRules.txt"),
        FileUtilities.ReadLines("./Resources/inputDayFiveUpdatePages.txt")
    ));

ResultWriter<int>.WriteResult("6", "1", () => DaySixService.GetTotalUniqueVisitedPositions(
    FileUtilities.ReadLines("./Resources/inputDaySix.txt")
));

ResultWriter<int>.WriteResult("6", "2", () => DaySixPartTwoService.FindLoopObstructionCount(
    FileUtilities.ReadLines("./Resources/inputDaySix.txt")
));

ResultWriter<long>.WriteResult("7", "1", () => DaySevenPartOneService.CalculateTotalCalibrationResult(
    FileUtilities.ReadLines("./Resources/inputDaySeven.txt")
));

ResultWriter<long>.WriteResult("7", "2", () => DaySevenPartTwoService.CalculateTotalCalibrationResultWithConcatenation(
    FileUtilities.ReadLines("./Resources/inputDaySeven.txt")
));

ResultWriter<int>.WriteResult("8", "1", () => DayEightPartOneService.CountAntinodes(
    FileUtilities.ReadLines("./Resources/inputDayEight.txt")
));

ResultWriter<int>.WriteResult("8", "2", () => DayEightPartTwoService.CountAntinodes(
    FileUtilities.ReadLines("./Resources/inputDayEight.txt")
));