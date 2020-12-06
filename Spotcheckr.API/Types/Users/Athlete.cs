using System;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Types.Contact;
using Spotcheckr.API.Types.Identity;

namespace Spotcheckr.API.Types.Users
{
	public class Athlete : IUser, INode
	{
		public int ID { get; set; }

		public string? Username { get; set; }

		public Uri? ProfilePicture { get; set; }

		public IdentityInformation IdentityInformation { get; set; }

		public ContactInformation ContactInformation { get; set; }
	}
}
