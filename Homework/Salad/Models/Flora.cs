namespace Salad.Models
{
	public abstract class Flora
	{
		protected Flora(bool isEdible, bool hasFruit)
		{
			IsEdible = isEdible;
			HasFruit = hasFruit;
		}

        public bool IsEdible { get; set; }
        public bool HasFruit { get; set; }
    }
}

