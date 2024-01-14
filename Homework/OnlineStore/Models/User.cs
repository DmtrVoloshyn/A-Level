namespace Models
{
	public class User
	{
		public Guid UserGuid { get; set; }
		public  string UserFirstName { get; set; }
        public  string UserLastName { get; set; }
        public string? UserEmail { get; set; }
	}
}

