public class Door : GameObject, IInteractable
{ 
    public bool IsLocked { get; set; }

    private Player _player;

    public Door(Player player) => Init(player);
    public void Init(Player player)
    {
        Symbol = 'D';
        _player = player;
    }

    public void ContractPlayer()
    {
        if(IsLocked)
        {
            // 잠겨있다.
        }

        else 
        {
            // 문을 열고 탈출
            SceneManager.Change("Ending");
        }
    }
}
