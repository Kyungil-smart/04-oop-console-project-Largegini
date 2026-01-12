using System;
using System.Collections.Generic;
using System.Data;
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
        NoticeText.Text = "답을 맞춰보자";
    }
    
    public void Update()
    {
        if (!IsActive) { return; }

        if(InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _submitAnswer.IncreaseValue();
        }

        if(InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _submitAnswer.DecreaseValue();
        }

        if(InputManager.GetKey(ConsoleKey.RightArrow))
        {
            _submitAnswer.SelectRight();
        }

        if(InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            _submitAnswer.SelectLeft();
        }

        if(InputManager.GetKey(ConsoleKey.Enter))
        {
            Solve();
        }

    }
    public void Render()
    {
        if(!IsActive) { return; }

        _submitAnswer.Render();
    }

    public void Solve()
    {
        int answer = _submitAnswer.GetAnswer();

        if (answer == _answer)
        {
            IsSolved = true;
            Symbol = "🔕";
            NoticeText.Text = "답을 맞췄다!";
        }

        else
        {
            NoticeText.Text = "답이 아닌 것 같다.";
        }
    }
}
