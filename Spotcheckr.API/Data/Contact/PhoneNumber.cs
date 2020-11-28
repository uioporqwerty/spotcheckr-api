using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotcheckr.API.Data
{
	[Table("PhoneNumbers")]
	public class PhoneNumber : IEntityTracking
	{
		public int Id { get; set; }

		[MaxLength(15)]
		public string Number { get; set; }

		[MaxLength(11)]
		public string? Extension { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}
