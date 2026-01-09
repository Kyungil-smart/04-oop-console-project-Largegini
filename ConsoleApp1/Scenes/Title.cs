using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Title : Scene
{
    private MenuList _titleMenu;
    private MenuList _guide;
    private GuideText _guideText;

    private bool _isGuideOpen;
    
    public Title()
    {
        Init();
    }

    public void Init()
    {
        _isGuideOpen = false;
        _guideText = new GuideText(ConsoleColor.Gray);

        _titleMenu = new MenuList();
        _titleMenu.Add("게임 시작", GameStart);
        _titleMenu.Add("HowtoPlay", HowtoPlay);
        _titleMenu.Add("게임 종료", GameQuit);

        _guide = new MenuList();
        foreach(string str in _guideText.Text) { _guide.Add(str, null); }
    }

    public override void Enter()
    {
        _titleMenu.Reset();   
    }

    public override void Update()
    {
        if(!_isGuideOpen)
        {
            SelectMove();
        }

        if(InputManager.GetKey(ConsoleKey.Enter))
        {
            _titleMenu.Select();
        }

        if(InputManager.GetKey(ConsoleKey.Escape))
        {
            _isGuideOpen = false;
        }
    }

    public override void Render()
    {
        Console.SetCursorPosition(6, 1);
        GameManager.GameTitle.Print(ConsoleColor.Green);

        _titleMenu.Render(4, 5, true);

        if(_isGuideOpen)
        {
            _guide.Render(3, 1);
        }
    }

    public override void Exit()
    {
        
    }

    public void GameStart()
    {
        SceneManager.Change("House");
    }

    public void HowtoPlay()
    {
        _isGuideOpen = true;
    }

    public void GameQuit()
    {
        GameManager.IsGameOver = true;
    }

    public void SelectMove()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _titleMenu.SelectUp();
        }
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _titleMenu.SelectDown();
        }
    }
}
