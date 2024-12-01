using Common.File;
using Common.Text;
using Days.One;

WelcomeWriter.WriteMessage();

ResultWriter<int>.WriteResult("1", "1", () => DayOneService
    .GetSummarizedDistance(FileUtilities.ReadLines("./Resources/inputDayOne.txt")));

ResultWriter<int>.WriteResult("1", "2", () => DayOneService
    .GetMultipliedSummarizedDistance(FileUtilities.ReadLines("./Resources/inputDayOne.txt")));

ResultWriter<int>.WriteResult("1", "2 v2", () => DayOneService
    .GetMultipliedSummarizedDistance2(FileUtilities.ReadLines("./Resources/inputDayOne.txt")));
