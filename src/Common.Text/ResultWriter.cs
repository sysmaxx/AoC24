using Common.Benchmark;

namespace Common.Text;

public static class ResultWriter<T> where T : notnull
{
    /// <summary>
    /// Writes the result of the provided function to the console.
    /// </summary>
    public static void WriteResult(string day, string part, Func<T> func)
    {
        var runtimeMeasureResult = DurationMeter<T>.MeasureRuntime(func);

        Console.WriteLine("");
        Console.WriteLine("________________________________");
        Console.WriteLine($"Day {day} Part {part}: {runtimeMeasureResult.Result}");
        Console.WriteLine($"Elapsed time: {runtimeMeasureResult.Duration} ms");
    }
}