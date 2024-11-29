using Common;
using Days.One;

Console.WriteLine("Hello, AoC24!");

Console.WriteLine("DayOne: " + DayOneService.GetSummarizedCalibrationValues(FileUtilities.ReadLines("./Resources/inputDayOne.txt").ToArray()));