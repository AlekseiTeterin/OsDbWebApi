namespace OsDbWebApi.Models.Entity
{
	// class - table
	// object of class - rows of table
	// fields - columns of table
	public class OperationSystems
	{
		public int Id { get; set; } // primary key
		public string? Name { get; set; }
		public string? Manufacturer { get; set; }
		public string? Description { get; set; } // string field
		public int VersionNumber { get; set; } // numeric field


		public override string ToString()
		{
			return $"{Id} - {Name} - {Manufacturer} - {Description} - {VersionNumber}";
		}
	}

	
}
