using System.Text;

namespace AOCHelpers.Extensions;

public static class InputHelpers
{
    /// <summary>
    /// Waits for any key to be pressed to stop the application
    /// </summary>
    public static void PressAnyKeyToExit()
    {
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        Environment.Exit(0);
    }

    /// <summary>
    /// Parses a string to an integer
    /// </summary>
    /// <param name="input">The input string to parse</param>
    /// <returns>The parsed int or null</returns>
    public static int? ParseToInt(this string input)
    {
        bool isInt = int.TryParse(input, out int amount);
        if (isInt)
        {
            return amount;
        }

        return null;
    }

    /// <summary>
    /// Create a new array from a subset of the input array
    /// </summary>
    /// <typeparam name="T">Array Type</typeparam>
    /// <param name="array">input array</param>
    /// <param name="offset">offset</param>
    /// <param name="length">length of new array</param>
    /// <returns></returns>
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        return array.Skip(offset)
            .Take(length)
            .ToArray();
    }

    /// <summary>
    /// Replace a string char at index with another char
    /// </summary>
    /// <param name="text">string to be replaced</param>
    /// <param name="index">position of the char to be replaced</param>
    /// <param name="c">replacement char</param>
    public static string ReplaceAtIndex(this string text, int index, char c)
    {
        var stringBuilder = new StringBuilder(text);
        stringBuilder[index] = c;
        return stringBuilder.ToString();
    }
}