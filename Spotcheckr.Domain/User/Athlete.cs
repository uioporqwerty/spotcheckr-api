using System;

namespace Spotcheckr.Domain
{
	public class Athlete : IUser
	{
		public string Id { get; set; }

		public string? Username { get; set; }

		public Uri? ProfilePicture { get; set; }

		public IdentityInformation IdentityInformation { get; set; }

		public ContactInformation? ContactInformation { get; set; }
	}
}
