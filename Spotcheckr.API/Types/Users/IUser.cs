using System;
using HotChocolate;
using Spotcheckr.API.Types.Contact;
using Spotcheckr.API.Types.Identity;
using Spotcheckr.API.Types.Relay;

namespace Spotcheckr.API.Types.Users
{
	[GraphQLDescription("Users can be of type Personal Trainer or Athlete.")]
	public interface IUser
	{
		[GraphQLDescription("Username for the user.")]
		public string? Username { get; set; }

		[GraphQLDescription("URL for the profile picture uploaded by the user.")]
		public Uri? ProfilePicture { get; set; }

		[GraphQLDescription("Details surrounding the identity of the user.")]
		public IdentityInformation IdentityInformation { get; set; }

		[GraphQLDescription("Contact details for the user.")]
		public ContactInformation ContactInformation { get; set; }
	}
}
