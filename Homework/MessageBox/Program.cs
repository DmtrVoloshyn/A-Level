using MessageBox.EventHandlers;

namespace MessageBox;

internal class Program
{
    public static void Main(string[] args)
    {
        var messageBox = new MessageBox();
        messageBox.CloseWindow += new CloseWindowEventHandler().CloseWindowHandler;

        messageBox.Open();
        Console.ReadKey();
    }
}