using System;

public class Submit
{
    public int _currentIndex;
    public int[] Answer;

    private Ractangle _outLine;

    public Submit() => Init();
    private PuzzleText _quesition;

    public void Init()
    {
        Answer = new int[4];
        _outLine = new Ractangle(width: 40, height:15);
        _quesition = new PuzzleText(ConsoleColor.Cyan);
    }
    //팝업 창
    public void Render()
    {
        int colum = 8;

        _outLine = new Ractangle(width: 40, height:15);
        _outLine.Draw();

        Console.SetCursorPosition((40-_quesition._text[0].GetTextWidth())/2,
            3);
        _quesition._text[0].Print(_quesition._color);

        for(int i=0; i< Answer.Length; i++)
        {
            _outLine = new Ractangle(colum, 11, 5, 3);
            _outLine.Draw();

            if(i== _currentIndex)
            {
                Console.SetCursorPosition(colum + 2, 10);
                "▼".Print(ConsoleColor.DarkCyan);
            }

            Console.SetCursorPosition(colum + 2, 12);
            Console.Write(Answer[i]);
            colum += 5;
        }
    }

    // 다이얼 식 정답
    // 위아래 입력하면 숫자변경
    public void IncreaseValue()
    {
        Answer[_currentIndex]++;

        if (Answer[_currentIndex] > 9) { Answer[_currentIndex] = 0; }
    }

    public void DecreaseValue()
    {
        Answer[_currentIndex]--;

        if(Answer[_currentIndex]<0) { Answer[_currentIndex] = 9; }
    }

    // 왼쪽 오른쪽으로 칸 변경
    public void SelectLeft()
    {
        _currentIndex--;

        if (_currentIndex < 0)
        {
            _currentIndex = 0;
        }
    }

    public void SelectRight()
    {
        _currentIndex++;

        if (_currentIndex >= Answer.Length)
        {
            _currentIndex = Answer.Length - 1;
        }
    }

    public int GetAnswer()
    {
        int intAnswer = 0;
        int digit = Answer.Length - 1;

        foreach (int i in Answer)
        {
            intAnswer += (i * (int)Math.Pow(10, digit));
            digit--;
        }

        return intAnswer;
    }
}
