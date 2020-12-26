namespace Spotcheckr.API.Domain
{
	public class Organization
	{
		public Organization(string abbreviation, string name)
		{
			Abbreviation = abbreviation;
			Name = name;
		}
		public int Id { get; set; }

		public string Abbreviation { get; set; }

		public string Name { get; set; }
	}
}
