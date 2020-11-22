using System.ComponentModel.DataAnnotations;

namespace Spotcheckr.API.Data
{
	public class Organization
	{
		[Key]
		public string Abbreviation { get; set; }

		public string Name { get; set; }
	}
}
