using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Puzzle : GameObject, IInteractable
{
    public bool IsSolved { get; set; }
    public bool IsActive;

    private int _answer;
    private int _currentIndex;

    private Player _player;
    private Submit _submitAnswer;
    public Puzzle(Player player) => Init(player);
    public void Init(Player player)
    {
        _answer = 1208;
        _currentIndex = 0;
        // 🔕
        Symbol = "🔔";

        _submitAnswer = new Submit();
        _player = player;

        IsSolved = false;
        IsActive = false;
    }

    public void ContractPlayer()
    {
        // 상호작용 시 팝업 띄우기
        _player.SolvePuzzle();
    }
    public void SelectLeft()
    {
        if(!IsActive) { return; }

        _currentIndex--;

        if (_currentIndex < 0)
        {
            _currentIndex = 0;
        }
    }

    public void SelectRight()
    {
        if(!IsActive) { return; }

        _currentIndex++;

        if (_currentIndex >= _submitAnswer.Answer.Length)
        {
            _currentIndex = _submitAnswer.Answer.Length - 1;
        }
    }

    public void Render()
    {
        if(!IsActive) { return; }

        _submitAnswer.Render();
    }

    public void Solve()
    {
        int intAnswer = 0;
        int digit = _submitAnswer.Answer.Length - 1;

        foreach(int i in _submitAnswer.Answer)
        {
            intAnswer += (i * (int)Math.Pow(10,digit));
            digit--;
        }

        if (intAnswer == _answer)
        {
            IsSolved = true; 

        }
    }
}
