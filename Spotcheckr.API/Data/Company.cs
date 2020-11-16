using System.ComponentModel.DataAnnotations;

namespace Spotcheckr.API.Data
{
	public class Company
	{
		public int Id { get; set; }

		[MaxLength(255)]
		public string Name { get; set; }
	}
}
