using System;
using System.Collections.Generic;
using System.Linq;

public class MenuList
{
    // 메뉴에 표시될 객체의 이름과 메서드를 저장하는 리스트
    private List<(string text, Action action)> _menus;

    private Ractangle _outline;

    private int _maxLength;

    private int _currentIndex;

    public int CurrentIndex { get => _currentIndex; }
    public string CurrentText { get => _menus[_currentIndex].text; }

    public MenuList(params (string, Action)[] menuTexts)
    {

        if (menuTexts.Length == 0) { _menus = new List<(string, Action)>(); }

        else { _menus = menuTexts.ToList(); }

        for (int i = 0; i < _menus.Count; i++)
        {
            int textWidth = _menus[i].text.GetTextWidth();

            if (_maxLength < textWidth) { _maxLength = textWidth; }
        }

        _outline = new Ractangle(width: _maxLength + 4, height: _menus.Count + 2);
    }

    public void Add(string text, Action action)
    {
        _menus.Add((text, action));

        int textWidth = text.GetTextWidth();
        if (_maxLength < textWidth) { _maxLength = textWidth; }

        _outline.Width = _maxLength + 6;
        _outline.Height++;
    }

    // 정해진 인덱스에 들어갈 오브젝트의 심볼과 기능을 넣기
    public void SetOnObject(int index, string symbol, Action action)
    {
        _menus[index] = (symbol, action);
    }

    public void Select()
    {
        if (_menus.Count == 0) { return; }

        _menus[_currentIndex].action?.Invoke();

        if (_currentIndex >= _menus.Count) { _currentIndex = _menus.Count - 1; }

        else if (_menus.Count == 0) { _currentIndex = 0; }
    }

    public void SelectUp()
    {
        _currentIndex--;

        if (_currentIndex < 0) { _currentIndex = 0; }
    }
    public void SelectDown()
    {
        _currentIndex++;

        if (_currentIndex >= _menus.Count) { _currentIndex = _menus.Count - 1; }
    }

    public void SelectLeft()
    {
        if (_currentIndex - 3 < 0) { return; }

        _currentIndex -= 3;
    }
    public void SelectRight()
    {
        if (_currentIndex + 3 > _menus.Count-1) { return; }

        _currentIndex += 3;
    }

    public void Render(int x, int y, bool needSelect = false)
    {
        _outline.X = x;
        _outline.Y = y;
        _outline.Draw();

        for (int i = 0; i < _menus.Count; i++)
        {
            y++;
            Console.SetCursorPosition(x + 2, y);

            if (i == _currentIndex && needSelect)
            {
                "▶".Print(ConsoleColor.DarkCyan);
                _menus[i].text.Print(ConsoleColor.DarkCyan);
                "◀".Print(ConsoleColor.DarkCyan);
                continue;
            }

            else
            {
                Console.Write(" ");
                _menus[i].text.Print();
            }
        }
    }
    public void CellRender(int x, int y)
    {
        _outline = new Ractangle(width: 9, height: 5);


        for (int i = 0; i < _menus.Count; i++)
        {
            if (i != 0 && i % 3 == 0)
            {
                x += 9;
                y = 0;
            }

            _outline.X = x;
            _outline.Y = y;
            _outline.Draw();

            Console.SetCursorPosition(x + 4, y+2);

            if (i == _currentIndex)
            {
                "P".Print(ConsoleColor.DarkCyan);
            }
            else
            {
                _menus[i].text.Print();
            }
            y += 5;
        }
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public void ResetCell(int index)
    {
        _menus[index] = (" ", null);
    }

    public void Remove()
    {
        _menus.RemoveAt(_currentIndex);

        int max = 0;

        foreach ((string text, Action action) in _menus)
        {
            int textWidth = text.GetTextWidth();

            if (max < textWidth) { max = textWidth; }
        }

        if (_maxLength != max) { _maxLength = max; }

        _outline.Width = _maxLength + 6;
        _outline.Height--;
    }

    public int GetListCount()
    {
        return _menus.Count;
    }
}
