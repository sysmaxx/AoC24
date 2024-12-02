using Common.File;
using Common.Text;
using Days.One;
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
