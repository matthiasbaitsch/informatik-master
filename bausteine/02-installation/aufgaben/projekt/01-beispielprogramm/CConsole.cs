namespace OOTetris;

public static class CConsole
{
    public static string Repeat(this string text, int n)
    {
        return string.Concat(Enumerable.Repeat(text, n));
    }

    public static void WriteLine(string text)
    {
        Console.ResetColor();
        Console.WriteLine(text);
    }

    public static void WriteLine(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    public static void Write(string text)
    {
        Console.ResetColor();
        Console.Write(text);
    }

    public static void Write(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
    }

    public static void Write(int row, int column, ConsoleColor color, string text)
    {
        Console.SetCursorPosition(column, row);
        Write(color, text);
    }

    public static void Write(int row, int column, string text)
    {
        Console.SetCursorPosition(column, row);
        Write(text);
    }

    public static void WriteLine(int row, int column, ConsoleColor color, string text)
    {
        Console.SetCursorPosition(column, row);
        WriteLine(color, text);
    }

    public static void WriteLine(int row, int column, string text)
    {
        Console.SetCursorPosition(column, row);
        WriteLine(text);
    }

    public static void Clear()
    {
        Console.Clear();
    }
}