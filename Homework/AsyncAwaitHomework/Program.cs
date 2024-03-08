namespace AsyncAwaitHomework;

internal class Program
{ 
    static async Task Main(string[] args)
    {
        var result = await ExecuteMethods();

        Console.WriteLine(result);
    }

    private static async Task<string> ReadFileAsync(string fileName)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        
        var filePath = Path.Combine(currentDirectory, $"{fileName}.txt");

        try
        {
            using (StreamReader reader = new(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static async Task<string> ExecuteMethods()
    {
        Task<string> task = ReadFileAsync("Hello");
        Task<string> task2 = ReadFileAsync("World");

        await Task.WhenAll(task, task2);

        var concutResult = task.Result + task2.Result;

        return concutResult;
    }
}