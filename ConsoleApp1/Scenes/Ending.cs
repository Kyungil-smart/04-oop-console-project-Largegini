using System;

public class Ending : Scene
{
    public override void Enter()
    {

    }

    public override void Update()
    {
        if(InputManager.GetKey(ConsoleKey.Enter))
        {
            GameManager.IsGameOver = true;
        }
    }

    public override void Render()
    {
        "Game Clear".Print(ConsoleColor.Yellow);
        Console.WriteLine();
        "탈출에 성공했다!!".Print(ConsoleColor.Yellow);
    }

    public override void Exit()
    {
        
    }
}
