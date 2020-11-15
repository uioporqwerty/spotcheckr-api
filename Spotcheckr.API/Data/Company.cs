using System.ComponentModel.DataAnnotations;

namespace Spotcheckr.API.Data
{
	public class Company
	{
		public int CompanyId { get; set; }

		[MaxLength(255)]
		public string Name { get; set; }

		public User User { get; set; }

		public int UserId { get; set; }
	}
}
