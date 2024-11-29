namespace Common;

public static class FileUtilities
{
    /// <summary>
    /// Reads all lines from the specified file and returns them as an IEnumerable<string>.
    /// </summary>
    /// <param name="filePath">The path to the file to read.</param>
    /// <returns>An IEnumerable<string> containing each line from the file.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs.</exception>
    public static IEnumerable<string> ReadLines(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");
        }

        // Use File.ReadLines to lazily read lines from the file
        return File.ReadLines(filePath);
    }
}