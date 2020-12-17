using System;

namespace Spotcheckr.Domain
{
	/// <summary>
	/// Phone number details.
	/// </summary>
	public class PhoneNumber : IEntityTracking, IEquatable<PhoneNumber>
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

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			var phoneNumber = (PhoneNumber)obj;
			return phoneNumber.Id == Id;
		}

		public override int GetHashCode() => Id.GetHashCode();

		public bool Equals(PhoneNumber other) => other.Id == Id;
	}
}
