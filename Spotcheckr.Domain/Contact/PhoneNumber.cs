using System;

namespace Spotcheckr.Domain
{
	/// <summary>
	/// Phone number details.
	/// </summary>
	public class PhoneNumber : IEntityTracking
	{
		/// <summary>
		/// Unique identifier for phone number.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Value of phone number.
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// Extension value of phone number.
		/// </summary>
		public string? Extension { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}
