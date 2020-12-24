using System;
using System.Collections.Generic;

namespace Spotcheckr.Models
{
	/// <summary>
	/// Personal trainer type of user with details specific to a personal trainer.
	/// </summary>
	public class PersonalTrainer : IUser
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

		/// <summary>
		/// Business or personal website for the personal trainer.
		/// </summary>
		public Uri? Website { get; set; }

		/// <summary>
		/// Certifications achieved by the personal trainer.
		/// </summary>
		public IEnumerable<Certification>? Certifications { get; set; }
	}
}
