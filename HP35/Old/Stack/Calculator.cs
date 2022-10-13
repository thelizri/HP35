namespace HP35;

public class Calculator
{
    Item[] expr;
    int instructiong_pointer;
    StaticStack<int> stack;

    public Calculator(Item[] expr)
    {
        this.expr = expr;
        this.instructiong_pointer = 0;
        this.stack = new DynamicStack<int>();
    }
    
    public int run() {
        while ( instructiong_pointer < expr.Length ) {
            step();
        }
        return stack.pop();
    }

    public void step()
    {
        Item next = expr[instructiong_pointer++];
        int x, y;
        switch (next.getType())
        {
            case ItemType.ADD:
                y = stack.pop();
                x = stack.pop();
                stack.push(x+y);
                break;
            case ItemType.SUB:
                y = stack.pop();
                x = stack.pop();
                stack.push(x-y);
                break;
            case ItemType.MUL:
                y = stack.pop();
                x = stack.pop();
                stack.push(x*y);
                break;
            case ItemType.DIV:
                y = stack.pop();
                x = stack.pop();
                stack.push(x/y);
                break;
            case ItemType.MOD:
                y = stack.pop();
                x = stack.pop();
                stack.push(x%y);
                break;
            case ItemType.VALUE:
                stack.push(next.getValue());
                break;
        }
    }
}