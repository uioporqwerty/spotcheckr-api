using System;

namespace Spotcheckr.Domain
{
	public interface IUser
	{
		/// <summary>
		/// Unique identifier for the user.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Username for the user.
		/// </summary>
		public string? Username { get; set; }

		/// <summary>
		/// URL for the profile picture uploaded by the user.
		/// </summary>
		public Uri? ProfilePicture { get; set; }

		/// <summary>
		/// Details surrounding the identity of the user.
		/// </summary>
		public IdentityInformation? IdentityInformation { get; set; }

		/// <summary>
		/// Contact details for the user.
		/// </summary>
		public ContactInformation? ContactInformation { get; set; }
	}
}
