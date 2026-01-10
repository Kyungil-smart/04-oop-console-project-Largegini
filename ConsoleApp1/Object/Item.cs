public abstract class Item : GameObject
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Player Owner { get; set; }

    public Inventory Bag { get; set; }

    public abstract void Use();
}
