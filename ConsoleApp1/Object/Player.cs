using System;
public class Player : GameObject
{
    private Inventory _inventory;

    public bool IsCanControl;
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

        return IsCanControl;
    }

    public void Render()
    {
        _inventory.Render();
    }
}
