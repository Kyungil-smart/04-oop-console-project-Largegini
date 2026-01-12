using System;
using System.Runtime.Remoting.Messaging;

public class KeyItem : Item, IInteractable
{
    Player _player;
    
    public KeyItem(Player player) => Init(player);

    public void Init(Player player)
    {
        _player = player;
        Symbol = "🗝️";
        Description = "잠긴문을 열 수 있는 열쇠다.";
        contractText = "열쇠를 얻었다!";
    }
    public override void Use()
    {
       
    }

    public void PrintInfo()
    {

    }

    public void ContractPlayer()
    {
        _player.AddItem(this);
    }
}