using System.Diagnostics;
using Common.Benchmark.Abstractions.Models;

namespace Common.Benchmark;

public static class DurationMeter<T> where T : notnull
{
    /// <summary>
    /// Measures the runtime of the provided function.
    /// </summary>
    public static RuntimeMeasureResult<T> MeasureRuntime(Func<T> func)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = func();
        stopwatch.Stop();
        return new RuntimeMeasureResult<T>(result, stopwatch.ElapsedMilliseconds);
    }
}