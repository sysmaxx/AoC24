using Common;
using Days.Example;
using Days.One;

Console.WriteLine("Hello, AoC24!");

Console.WriteLine("Example Day: " + 
                  DayExampleService
                      .GetSummarizedCalibrationValues(FileUtilities.ReadLines("./Resources/inputExampleOne.txt")));

Console.WriteLine("Day One Part 1: " + 
                  DayOneService
                      .GetSummarizedDistance(FileUtilities.ReadLines("./Resources/inputDayOne.txt")));
                                           
Console.WriteLine("Day One Part 2: " + 
                  DayOneService
                      .GetMultipliedSummarizedDistance(FileUtilities.ReadLines("./Resources/inputDayOne.txt")));