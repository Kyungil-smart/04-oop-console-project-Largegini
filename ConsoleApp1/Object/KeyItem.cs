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
    }
    public override void Use()
    {
        if (Owner.UnlockDoor())
        {
            // 사용시 인벤토리에서 제거
            Bag.Remove(this);
            Bag = null;
            Owner = null;
        }
    }

    public void PrintInfo()
    {

    }

    public void ContractPlayer()
    {
        _player.AddItem(this);
        NoticeText.Text = "열쇠를 얻었다!";
    }
}