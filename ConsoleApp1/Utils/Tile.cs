using System;

public struct Tile
{
    // 타일 위에 뭐가 올라와 있는지
    public GameObject OnTileObject { get; set; }

    // 플레이어가 상호작용하면 발생하는 이벤트
    public event Action ContractPlayer;

    // 자신의 좌표
    public Vector Position { get; set; }

    public bool HasGameObject => OnTileObject != null;

    public Tile(Vector pos)
    {
        ContractPlayer = null;
        OnTileObject = null;

        Position = pos;
    }

    public void Print()
    {
        if(HasGameObject)
        {
            OnTileObject.Symbol.Print();
        }

        else { ' '.Print(); }
    }
}
