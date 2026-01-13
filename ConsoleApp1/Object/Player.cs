using System;
using System.Reflection;
public class Player : GameObject
{
    private Inventory _inventory;

    public MenuList RoomCell;
    public GameObject[] InroomObject;

    private GameObject _currentObj;
    private Puzzle _solvingPuzzle;

    public bool IsCanControl { get; set; }
    public Player() => Init();

    public void Init()
    {
        _inventory = new Inventory(this);
        _currentObj = null;
        _solvingPuzzle = null;

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
            if(_solvingPuzzle !=null && _solvingPuzzle.IsActive) { return false; }

            _inventory.IsActive = !_inventory.IsActive;
            IsCanControl = !_inventory.IsActive;
        }

        if(InputManager.GetKey(ConsoleKey.Escape))
        {
            _inventory.IsActive = false;

            if(_solvingPuzzle !=null)
                _solvingPuzzle.IsActive = false;

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

        //  - 아이템 사용
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _inventory.Select();
        }


        _solvingPuzzle?.Update();

        return IsCanControl;
    }

    public void Render()
    {
        _inventory.Render();
        _solvingPuzzle?.Render();
    }

    public bool UnlockDoor()
    {
        _currentObj = InroomObject[RoomCell.CurrentIndex];
        // 엉뚱한 곳에서 열쇠를 쓰지 못하게 하기
        if (_currentObj  == null)
        {
            NoticeText.Text = "사용할 수 없다.";
            return false;
        }

        else if (_currentObj is Door )
        {
            // 사용해서 잠금해제
            (_currentObj as Door).Unlock();

            _currentObj = null;
            return true;
        }
        return false;
    }
    public void SolvePuzzle()
    {
        _currentObj = InroomObject[RoomCell.CurrentIndex];
        if ( _currentObj is Puzzle)
        {
            _solvingPuzzle = _currentObj as Puzzle;
            _solvingPuzzle.IsActive = true;
            IsCanControl = !_solvingPuzzle.IsActive;
        }

        else { _solvingPuzzle = null; }
    }
}
