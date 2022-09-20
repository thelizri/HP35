namespace HP35;

public class Item
{
    private ItemType type;
    private int value;
    
    public Item(ItemType type, int value = 0)
    {
        this.type = type;
        this.value = value;
    }

    public ItemType getType()
    {
        return this.type;
    }

    public int getValue()
    {
        return this.value;
    }
}

public enum ItemType
{
    ADD,
    SUB,
    MUL,
    DIV,
    MOD,
    VALUE
}