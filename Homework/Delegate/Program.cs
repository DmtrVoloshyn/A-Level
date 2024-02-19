namespace Delegate;

class Program
{
    public static void Main(string[] args)
    {
        //implementation via simple delegates
        FirstClass firstClass = new();
        SecondClass secondClass = new();

        ShowDelegate showDelegate = Show;
        var resultDelegate = secondClass.Calc(5, 5, firstClass.Multiply);
        showDelegate(resultDelegate(5));

        //implementation via delegate add-ons
        SecondClass2 secondClass2 = new();

        var resultDelegate2 = secondClass2.Calc(5, 5, firstClass.Multiply);
        showDelegate(resultDelegate(6));

        //implementation event homework
        CalculateEventHandler handler = new();
        firstClass.CalculateEvent += handler.HandleCalculate;

        firstClass.CalculateSum();
    }

    public static void Show(bool result)
    {
        Console.WriteLine(result);
    }

    public static void TryCatchWrapper()
    {
        try
        {
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Handled error: {ex.Message}");
        }
    }
}