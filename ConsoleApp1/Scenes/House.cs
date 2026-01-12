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
    //  - 조사가능한 오브젝트
    //      - 퍼즐
    //      - 아이템 사용할 수 있는 곳
    //      - 열쇠 획득
    private GameObject[] InroomObeject;
    //  - 문
    //  - 잠긴문
    public House(Player player) => Init(player);

    private string _noticeText;
    private bool _canControl;

    public void Init(Player player)
    {
        _player = player;
        _noticeText = "방을 탈출하자!";
        _canControl = true;

        // 빈공간으로 먼저 방을 구성
        _roomCell = new MenuList();
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);
        _roomCell.Add(" ", null);

        // 방안에 있을 오브젝트 리스트 초기화
        InroomObeject = new GameObject[_roomCell.GetListCount()];
        SetDesign(1);

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

    }

    public override void Update()
    {
        // 행동을 선택지로 제공
        // 1. 이동
        if (_canControl)
        {
            if (InputManager.GetKey(ConsoleKey.UpArrow))
            {
                _roomCell.SelectUp();
            }
            if (InputManager.GetKey(ConsoleKey.DownArrow))
            {
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
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            int index = _roomCell.CurrentIndex;
            if (InroomObeject[index] is KeyItem)
            {
                _noticeText = (InroomObeject[index]as KeyItem).GetText;
                _roomCell.Select();
                _roomCell.ResetCell(index);
                InroomObeject[index] = null;
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

    }

    private void GetItemAction()
    {
    }

    private void SetDesign(int ObjectNum)
    {
        Random ranNum = new Random();
        int ranIndex = ranNum.Next(0, InroomObeject.Length);
        InroomObeject[ranIndex] = new KeyItem(_player) { Name = "열쇠" };

        if (InroomObeject[ranIndex] is IInteractable)
        {
            IInteractable InteractableObj = InroomObeject[ranIndex] as IInteractable;
            _roomCell.SetOnObject(ranIndex, InroomObeject[ranIndex].Symbol,
             InteractableObj.ContractPlayer);
        }
    }
}
