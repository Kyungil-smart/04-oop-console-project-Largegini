using System;

public struct PuzzleText
{
    public string[] _text;

    public ConsoleColor _color { get; set; }

    public PuzzleText(ConsoleColor color) 
    {
        _text = new string[]
        {
            "플밍 4기의 개강일은?"
        };

        _color = color;
    }

}