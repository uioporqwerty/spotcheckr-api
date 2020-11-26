using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotcheckr.API.Data
{
	[Table("Emails")]
	public class Email : IEntityTracking
	{
		public int Id { get; set; }

		[MaxLength(254)]
		public string Address { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
