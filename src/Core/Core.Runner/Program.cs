using Common;
using Days.Example;

Console.WriteLine("Hello, AoC24!");

Console.WriteLine("DayOne: " + 
                  DayExampleService
                      .GetSummarizedCalibrationValues(FileUtilities.ReadLines("./Resources/inputExampleOne.txt")));