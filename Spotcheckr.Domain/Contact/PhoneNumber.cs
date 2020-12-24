using System;

namespace Spotcheckr.Domain
{
	public class PhoneNumber : IEntityTracking
	{
		public int Id { get; set; }

		public string Number { get; set; }

		public string? Extension { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}
