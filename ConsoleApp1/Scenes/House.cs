using System;
using System.Diagnostics;
using System.Linq;

public class House : Scene
{
    private Player _player;
    // 플레이 구역을 3X3구조로 쓰자
    //private Tile[,] _room = new Tile[3, 3];
    private MenuList _roomCell;
    // 방마다 있어야 할 것이 뭐지
    private GameObject[] InroomObject;
    //  - 조사가능한 오브젝트
    //      - 퍼즐
    //      - 아이템 사용할 수 있는 곳
    //  - 문
    //  - 잠긴문
    Random ranNum;
    public House(Player player) => Init(player);

    private string _noticeText;
    private bool _canControl;

    public void Init(Player player)
    {
        ranNum = new Random();
        _player = player;
        _noticeText = "방을 탈출하자!";
        _canControl = true;

        // 빈공간으로 먼저 방을 구성
        _roomCell = new MenuList();
        ResetRoom();

        // 방안에 있을 오브젝트 리스트 초기화
        InroomObject = new GameObject[_roomCell.GetListCount()];
        
        //for(int y =0; y<_room.GetLength(0); y++)
        //{
        //    for(int x =0; x < _room.GetLength(1); x++)
        //    {
        //        Vector pos = new Vector(x, y);
        //        _room[y, x] = new Tile(pos);
        //    }
        //}
    }

    public override void Enter()
    {
        InroomObject[5] =  new Door(_player);
        _roomCell.SetOnObject(5, InroomObject[5].Symbol,
            GetInteractable(InroomObject[5]).ContractPlayer);
        SetDesign();
    }

    public override void Update()
    {
        // 행동을 선택지로 제공
        // 1. 이동
        if (_canControl)
        {
            if (InputManager.GetKey(ConsoleKey.UpArrow))
            {
                if(_roomCell.CurrentIndex % 3 ==0) { return; }

                _roomCell.SelectUp();
            }
            if (InputManager.GetKey(ConsoleKey.DownArrow))
            {
                if (_roomCell.CurrentIndex % 3 == 2) { return; }

                _roomCell.SelectDown();
            }
            if (InputManager.GetKey(ConsoleKey.LeftArrow))
            {
                _roomCell.SelectLeft();
            }
            if (InputManager.GetKey(ConsoleKey.RightArrow))
            {
                _roomCell.SelectRight();
            }
        }

        // 2. 조사
        //  - 아이템 획득
        //      - 열쇠 획득
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            int index = _roomCell.CurrentIndex;
            _roomCell?.Select();
            _noticeText = (InroomObject[index]?.GetText);

            if (InroomObject[index] is KeyItem)
            {
                _roomCell.ResetCell(index);
                InroomObject[index] = null;
            }
        }

        _canControl = _player.Update();
        
        //  - 잠긴문이면 이동불가
        //  - 퍼즐
        //  - 아이템 사용
    }

    public override void Render()
    {
        //PrintRoomCell();
        _roomCell.CellRender(0, 0);

        _player.Render();

        Console.SetCursorPosition(0, 16);
        Console.Write(_noticeText);
    }

    public override void Exit()
    {
        ResetRoom();
        ResetObject();
    }
    private void SetDesign()
    {
        
        int ranIndex = ranNum.Next(0, InroomObject.Length);

        if (ranIndex != 5)
        {
            if (InroomObject[ranIndex] != null) { return; }

            InroomObject[ranIndex] = new KeyItem(_player) { Name = "열쇠" };

            IInteractable InteractableObj = GetInteractable(InroomObject[ranIndex]);
            _roomCell.SetOnObject(ranIndex, InroomObject[ranIndex].Symbol,
             InteractableObj.ContractPlayer);
        }

        else { SetDesign(); }
    }

    private IInteractable GetInteractable( GameObject gameObject )
    {
        if (gameObject is IInteractable)
        {
            IInteractable InteractableObj = gameObject as IInteractable;

            return InteractableObj;
        }

        return null;
    }

    private void ResetRoom()
    {
        for (int i = 0; i < 9; i++)
        {
            _roomCell.Add(" ", null);
        }
    }

    private void ResetObject()
    {
        for (int i = 0; i < 9; i++)
        {
            InroomObject[i] = null;
        }
    }
}
