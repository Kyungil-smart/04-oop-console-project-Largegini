public class Door : GameObject, IInteractable
{ 
    public bool IsLocked { get; set; }

    private Player _player;

    public Door(Player player) => Init(player);
    public void Init(Player player)
    {
        Symbol = "🔒";
        _player = player;
        // 잠겨있다.
        IsLocked = true;
    }

    public void ContractPlayer()
    {
        if(IsLocked)
        {
            NoticeText.Text = "잠겨있다. 열쇠가 필요할 것 같다.";
        }

        else 
        {
            // 문을 열고 탈출
            SceneManager.Change("Ending");
        }
    }

    public void Unlock()
    {
        Symbol = "🔓";
        _player.RoomCell.SetOnObject(_player.RoomCell.CurrentIndex,
            Symbol, ContractPlayer);
        NoticeText.Text = "문이 열렸다!";
        IsLocked = false;
    }
}
