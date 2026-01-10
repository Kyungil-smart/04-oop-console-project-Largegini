
public class Player : GameObject
{
    private Inventory _inventory;

    public Player() => Init();

    public void Init()
    {
        _inventory = new Inventory(this);
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }
}
