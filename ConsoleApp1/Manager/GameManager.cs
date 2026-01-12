using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

public class GameManager
{
    private Player _player;

    public static bool IsGameOver { get; set; }

    public const string GameTitle = "HourHomes";

    private int Timecount;

    private void Init()
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = Encoding.UTF8;

        IsGameOver = false;
        _player = new Player();
        //Console.SetBufferSize(256, 256);

        SceneManager.AddScene("Title", new Title());
        SceneManager.AddScene("House", new House(_player));
        SceneManager.AddScene("Ending", new Ending());

        SceneManager.Change("Title");
    }

    public void Run()
    {
        Init();

        while(!IsGameOver)
        {
            // 출력
            Console.Clear();
            SceneManager.Render();

            // 키 입력
            InputManager.GetUserInput();

            // 데이터 처리
            SceneManager.Update();
        }
    }
}
