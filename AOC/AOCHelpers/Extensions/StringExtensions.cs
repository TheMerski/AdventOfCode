namespace AOCHelpers.Extensions;

/// <summary>
/// Class for reading information from files
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Read a file into an array of integers
    /// </summary>W
    /// <param name="filePath">Path of the file to read</param>
    /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
    /// <returns>An array of numbers</returns>
    public static int[] ToIntArray(this string resource, string seperator = ",")
    {
        string text = resource;
        string[] numbers = text.Split(seperator);
        return Array.ConvertAll(numbers, int.Parse);
    }

    /// <summary>
    /// Read a file into an array of integers
    /// </summary>
    /// <param name="filePath">Path of the file to read</param>
    /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
    /// <returns>An array of numbers</returns>
    public static int[] ToIntArray(this string resource, char seperator = ',')
    {
        string text = resource;
        string[] numbers = text.Split(seperator);
        return Array.ConvertAll(numbers, int.Parse);
    }

    /// <summary>
    /// Read a file into an array of longs
    /// </summary>W
    /// <param name="filePath">Path of the file to read</param>
    /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
    /// <returns>An array of numbers</returns>
    public static long[] ToLongArray(this string resource, string seperator = ",")
    {
        string text = resource;
        string[] numbers = text.Split(seperator);
        return Array.ConvertAll(numbers, Int64.Parse);
    }

    /// <summary>
    /// Read a file into an array of longs
    /// </summary>
    /// <param name="filePath">Path of the file to read</param>
    /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
    /// <returns>An array of numbers</returns>
    public static long[] ToLongArray(this string resource, char seperator = ',')
    {
        string text = resource;
        string[] numbers = text.Split(seperator);
        return Array.ConvertAll(numbers, Int64.Parse);
    }

    /// <summary>
    /// Read a file into an array of strings
    /// </summary>
    /// <param name="filePath">Path of the file to read</param>
    /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
    /// <returns>An array of strings</returns>
    public static string[] ToStringArray(this string resource, string seperator = ",")
    {
        string text = resource;
        return text.Split(seperator);
    }


    /// <summary>
    /// Read a file into an array of strings
    /// </summary>
    /// <param name="filePath">Path of the file to read</param>
    /// <param name="seperator">Seperator used to seperate numbers (default = ,)</param>
    /// <returns>An array of strings</returns>
    public static string[] ToStringArray(this string resource, char seperator = ',')
    {
        string text = resource;
        return text.Split(seperator);
    }

}