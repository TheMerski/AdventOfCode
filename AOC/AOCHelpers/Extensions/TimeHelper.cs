using System.Diagnostics;

namespace AOCHelpers.Extensions;

/// <summary>
/// Class for helping keep track of time
/// </summary>
class TimeHelper
{
    private Stopwatch stopwatch;

    public TimeHelper()
    {
        stopwatch = new Stopwatch();
    }

    /// <summary>
    /// Start stopwatch
    /// </summary>
    public void Start()
    {
        stopwatch.Start();
    }

    /// <summary>
    /// Stop stopwatch and display elapsed time
    /// </summary>
    public void Stop()
    {
        stopwatch.Stop();
        Console.WriteLine("Program ran for: " + stopwatch.ElapsedMilliseconds + "ms");
        InputHelpers.PressAnyKeyToExit();
    }

}