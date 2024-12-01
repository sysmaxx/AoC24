namespace Common.Benchmark.Abstractions.Models;

/// <summary>
/// Represents the result of a runtime measure.
/// </summary>
public record RuntimeMeasureResult<T>(T Result, long Duration) where T : notnull;