//public delegate int Operate(int x, int y);

public class Button
{
    public delegate void ClickEventHandler(object sender, EventArgs args);
    public event ClickEventHandler Click;
    public void Press()
    {
        Console.WriteLine("Press");
        OnClick(EventArgs.Empty);
    }

    protected virtual void OnClick(EventArgs e)
    {
        Click.Invoke(this, e);
    }
}

public class EventHandler
{
    public void HandleClick(object sender, EventArgs args)
    {
        Console.WriteLine("Button clicked!");
    }
}

class Program
{
    //public static int PerformOperation(int x, int y, Operate operate)
    //{
    //    return operate(x, y);
    //}

    //public static int Add(int x, int y)
    //{
    //    return x + y;
    //}

    public static void Main(string[] args)
    {
        //Operate operate1 = Add;
        //var result1 = PerformOperation(10, 5, operate1);
        //Console.WriteLine($"result1 {result1}");


        //Operate operate2 = delegate (int x, int y) { return x - y; };
        //var result2 = PerformOperation(10,5,operate2);
        //Console.WriteLine($"result2 {result2}");

        //Operate operate3 = (x, y) => x * y;
        //var result3 = PerformOperation(10, 5, operate3);
        //Console.WriteLine($"result3 {result3}");

        Button button = new();
        EventHandler eventHandler = new();

        button.Click += eventHandler.HandleClick;
        button.Press();
    }
}