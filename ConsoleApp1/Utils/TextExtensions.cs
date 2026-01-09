using System;

public static class TextExtensions
{
    public static void Print(this string text, ConsoleColor color = ConsoleColor.Gray)
    {
        if (color != ConsoleColor.Gray) { Console.ForegroundColor = color; }

        Console.Write(text);

        if(color != ConsoleColor.Gray) { Console.ResetColor(); }
    }

    public static void Print(this char cha, ConsoleColor color = ConsoleColor.Gray)
    {
        if (color != ConsoleColor.Gray) { Console.ForegroundColor = color; }

        Console.Write(cha);

        if (color != ConsoleColor.Gray) { Console.ResetColor(); }
    }

    public static int GetTextWidth(this string text)
    {
        int width = 0;
        foreach(char c in text) { width += c.GetCharacterWidth(); }

        return width;
    }

    public static int GetCharacterWidth(this char character)
    {
        if ((character >= '\uAC00' && character <= '\uD7A3') ||
            (character >= '\u1100' && character <= '\u11FF') ||
            (character >= '\u3130' && character <= '\u318F') ||
            (character >= '\uFf01' && character <= '\uFF60') ||
            (character >= '\uFFE0' && character <= '\uFFE6'))
            { return 2; }

        else { return 1; }
    }
}
