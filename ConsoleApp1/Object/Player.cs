using System;
using System.Reflection;
public class Player : GameObject
{
    private Inventory _inventory;

    public MenuList RoomCell;
    public GameObject[] InroomObject;

    public bool IsCanControl { get; set; }
    public Player() => Init();

    public void Init()
    {
        _inventory = new Inventory(this);
        IsCanControl = true;
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public bool Update()
    {
        if (InputManager.GetKey(ConsoleKey.Tab))
        {
            _inventory.IsActive = !_inventory.IsActive;
            IsCanControl = !_inventory.IsActive;
        }

        if(InputManager.GetKey(ConsoleKey.Escape))
        {
            _inventory.IsActive = false;
            IsCanControl = true;
        }

        if(InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _inventory.SelectUp();
        }

        if(InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _inventory.SelectDown();
        }

        if(InputManager.GetKey(ConsoleKey.Enter))
        {
            _inventory.Select();
        }

        return IsCanControl;
    }

    public void Render()
    {
        _inventory.Render();
    }

    public bool UnlockDoor()
    {
        if(InroomObject[RoomCell.CurrentIndex] == null)
        {
            NoticeText.Text = "사용할 수 없다.";
            return false;
        }
        else if (InroomObject[RoomCell.CurrentIndex] is Door )
        {
            // 사용해서 잠금해제
            (InroomObject[RoomCell.CurrentIndex] as Door).Unlock();
            return true;
        }
        return false;
    }
}
