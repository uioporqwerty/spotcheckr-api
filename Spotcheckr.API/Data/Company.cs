using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotcheckr.API.Data
{
	[Table("Companies")]
	public class Company
	{
		public int Id { get; set; }

		[MaxLength(255)]
		public string Name { get; set; }
	}
}
