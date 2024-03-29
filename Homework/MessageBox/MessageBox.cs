using MessageBox.Enums;

namespace MessageBox;

public class MessageBox
{
    public event EventHandler<State>? CloseWindow;

    public async void Open()
    {
        Console.WriteLine("window is open");
        await Task.Delay(TimeSpan.FromSeconds(3));
        Console.WriteLine("window was closed by the user");
        
        CloseWindow?.Invoke(this,GetRandomState());
    }

    private static State GetRandomState()
    {
        var random = new Random();
        var randomIndex = random.Next(0, 2);
        
        return (State)randomIndex;
    }
}