using System;

namespace Spotcheckr.Models
{
	/// <summary>
	/// Email address details.
	/// </summary>
	public class Email : IEquatable<Email>
	{
		/// <summary>
		/// Unique identifier for email address.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Email address value.
		/// </summary>
		public string Address { get; set; }

		public IUser User { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			var email = (Email)obj;
			return email.Id == Id;
		}

		public override int GetHashCode() => Id.GetHashCode();

		public bool Equals(Email other) => other.Id == Id;
	}
}
