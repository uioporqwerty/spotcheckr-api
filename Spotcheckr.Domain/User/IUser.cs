using System;

namespace Spotcheckr.Domain
{
	public interface IUser
	{
		public int Id { get; set; }

		public string? Username { get; set; }

		public Uri? ProfilePicture { get; set; }

		public IdentityInformation IdentityInformation { get; set; }

		public ContactInformation? ContactInformation { get; set; }
	}
}
