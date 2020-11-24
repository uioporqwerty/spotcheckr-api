using System.ComponentModel.DataAnnotations;

namespace Spotcheckr.API.Data
{
	public class Organization
	{
		public int Id { get; set; }

		public string Abbreviation { get; set; }

		public string Name { get; set; }
	}
}
