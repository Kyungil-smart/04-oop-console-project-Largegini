using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class InputManager
{
    private static ConsoleKey _current;
    private static readonly ConsoleKey[] _keys =
    {
        ConsoleKey.UpArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.LeftArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.Escape,
        ConsoleKey.Enter,
        ConsoleKey.Tab
    };

    public static void GetUserInput()
    {
        ConsoleKey input = Console.ReadKey(true).Key;
        _current = ConsoleKey.Clear;

        foreach (ConsoleKey key in _keys)
        {
            if(input == key)
            {
                _current = input;
                break;
            }
        }
    }

    public static bool GetKey(ConsoleKey input)
    {
        return _current == input;
    }

    public static void ResetKey()
    {
        _current = ConsoleKey.Clear;
    }
}
