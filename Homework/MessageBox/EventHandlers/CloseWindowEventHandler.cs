using MessageBox.Enums;

namespace MessageBox.EventHandlers;

public class CloseWindowEventHandler
{
    public void CloseWindowHandler(object? sender, State state)
    {
        switch (state)
        {
            case State.Ok:
                Console.WriteLine("the operation has been confirmed");
                break;
            case State.Cancel:
                Console.WriteLine("the operation was rejected");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}