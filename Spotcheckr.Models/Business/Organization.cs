namespace Spotcheckr.Models
{
	/// <summary>
	/// An organization is a fitness service provider that issues certifications.
	/// </summary>
	public class Organization
	{
		public Organization(string abbreviation, string name)
		{
			Abbreviation = abbreviation;
			Name = name;
		}

		/// <summary>
		/// Unique identifier of the organization.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Abbreviation defined by the organization.
		/// </summary>
		public string Abbreviation { get; set; }

		/// <summary>
		/// Name of the organization.
		/// </summary>
		public string Name { get; set; }
	}
}
