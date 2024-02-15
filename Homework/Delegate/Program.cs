using static Delegate.FirstClass;
using static Delegate.SecondClass;

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
    }

    public static void Show(bool result)
    {
        Console.WriteLine(result);
    }
}