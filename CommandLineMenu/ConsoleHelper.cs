namespace CommandLineMenu;

/// <summary>
/// Help functions for the <see cref="Console"/> class."/>
/// </summary>
internal static class ConsoleHelper
{
    /// <summary>
    /// Clears the current line in the console.
    /// </summary>
    public static void ClearLine()
    {
        Console.CursorLeft = 0;
        Console.Write(new string(' ', Console.WindowWidth));
        Console.CursorLeft = 0;
    }
}
