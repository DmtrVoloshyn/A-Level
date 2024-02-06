namespace CustomGeneric
{
	public class Startup
	{
		public Startup()
		{
		}

		public void Start()
		{
			CustomCollection<int> customCollection = new CustomCollection<int>();

			customCollection.Add(5);
			customCollection.Add(10);
			customCollection.Add(1003);

			Console.WriteLine("Default collection: ");
			foreach (var item in customCollection)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("\nSorted collectin: ");
			customCollection.Sort();
			foreach (var item in customCollection)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("\nCollection with default value set to 0: ");
			customCollection.SetDefaultAt(index: 0);
			foreach (var item in customCollection)
			{
				Console.WriteLine(item);
			}
		}
	}
}

