using System;
using System.ComponentModel.DataAnnotations;

namespace Spotcheckr.API.Data
{
	public class Email : IEntityTracking
	{
		public User User { get; set; }

		public int UserId { get; set; }

		[MaxLength(254)]
		public string Address { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
