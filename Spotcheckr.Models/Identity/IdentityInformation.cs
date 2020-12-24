using System;

namespace Spotcheckr.Models
{
	/// <summary>
	/// Identity details for the user.
	/// </summary>
	public class IdentityInformation
	{
		/// <summary>
		/// User first name.
		/// </summary>
		public string? FirstName { get; set; }

		/// <summary>
		/// User middle name.
		/// </summary>
		public string? MiddleName { get; set; }

		/// <summary>
		/// User last name.
		/// </summary>
		public string? LastName { get; set; }

		/// <summary>
		/// User birth date.
		/// </summary>
		public DateTime? BirthDate { get; set; }
	}
}
