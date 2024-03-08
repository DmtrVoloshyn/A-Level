namespace Delegate;

class Program
{
    public static void Main(string[] args)
    {
        //implementation via simple delegates
        FirstClass firstClass = new();
        SecondClass secondClass = new();

        ShowDelegate showDelegate = Show;
        var resultDelegate = secondClass.Calc(5, 5, FirstClass.Multiply);
        showDelegate(resultDelegate(5));

        //implementation via delegate add-ons
        SecondClass2 secondClass2 = new();

        var resultDelegate2 = secondClass2.Calc(5, 5, FirstClass.Multiply);
        showDelegate(resultDelegate(6));

        //implementation event homework
        CalculateEventHandler handler = new();
        firstClass.CalculateEvent += handler.HandleCalculate;
        firstClass.CalculateEvent += handler.HandleCalculate;

        TryCatchWrapper(() => firstClass.CalculateSum(5,5));

        Console.WriteLine(handler.SumResults());

        //LINQ
        List<Contact> _contacts = new List<Contact>
        {
            new Contact { Name = "Ivan Talabira", Phone = "380995552233" },
            new Contact { Name = "Petro Ivanov", Phone = "380995552233" },
            new Contact { Name = "Antin Kuts", Phone = "380995552233" },
            new Contact { Name = "Valeriy", Phone = "380995552233" },
            new Contact { Name = "Сантехнік", Phone = "380995552233" },
            new Contact { Name = "Автомийка", Phone = "380995552233" },
            new Contact { Name = "Ян", Phone = "380995552233" },
            new Contact { Name = ".net", Phone = "380995552233" },
            new Contact { Name = "////", Phone = "380995552233" },
            new Contact { Name = "John Smith", Phone = "1234567890" },
            new Contact { Name = "Emily Davis", Phone = "9876543210" },
            new Contact { Name = "David Johnson", Phone = "5555555555" },
            new Contact { Name = "Olivia White", Phone = "5551234567" },
            new Contact { Name = "Liam Brown", Phone = "5559876543" },
            new Contact { Name = "Sophia Wilson", Phone = "5554445555" },
            new Contact { Name = "James Lee", Phone = "5552223333" },
            new Contact { Name = "Emma Taylor", Phone = "5556667777" },
            new Contact { Name = "Logan Miller", Phone = "5558889999" },
            new Contact { Name = "Ava Jackson", Phone = "5551110000" },
            new Contact { Name = "Іван Талабіра", Phone = "380995552233" },
            new Contact { Name = "Петро Іванов", Phone = "380995552233" },
            new Contact { Name = "Антін Куц", Phone = "380995552233" }
        };

        var firstContact = _contacts.FirstOrDefault();
        Console.WriteLine("First Contact: " + firstContact?.Name);

        var filteredContacts = _contacts.Where(x => x.Phone.StartsWith("555"));
        Console.WriteLine("\nContacts with Phone Starting with '555':");
        foreach (var contact in filteredContacts)
        {
            Console.WriteLine($"{contact.Name}: {contact.Phone}"); ;
        }

        var contactNames = _contacts.Select(x => x.Name);
        Console.WriteLine("\nContact Names:");
        foreach (var name in contactNames)
        {
            Console.WriteLine(name);
        }

        var orderedContacts = _contacts.OrderBy(x => x.Name);
        Console.WriteLine("\nContacts Ordered by Name:");
        foreach (var contact in orderedContacts)
        {
            Console.WriteLine(contact.Name);
        }

        var skippedContacts = _contacts
            .Skip(5)
            .OrderBy(x => x.Name);
        Console.WriteLine("\nContacts after Skipping 5:");
        foreach (var contact in skippedContacts)
        {
            Console.WriteLine(contact.Name);
        }
    }

    private static void Show(bool result)
    {
        Console.WriteLine(result);
    }

    private static void TryCatchWrapper(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when handling event: {ex.Message}");
        }
    }
}