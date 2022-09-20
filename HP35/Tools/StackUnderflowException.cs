namespace HP35;

public class StackUnderflowException : Exception
{
    public StackUnderflowException(string? message) : base(message)
    {
    }
}