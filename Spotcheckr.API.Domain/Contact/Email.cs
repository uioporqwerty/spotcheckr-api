using System;

namespace Spotcheckr.API.Domain
{
	public class Email : IEntityTracking
	{
		public int Id { get; set; }

		public string Address { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}
