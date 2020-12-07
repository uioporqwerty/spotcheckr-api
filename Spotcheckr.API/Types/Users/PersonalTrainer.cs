using System;
using System.Collections.Generic;
using HotChocolate;
using Spotcheckr.API.Types.Identity;
using Spotcheckr.API.Types.Relay;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Users
{
	[GraphQLDescription("Represents a personal trainer type of user.")]
	public class PersonalTrainer : IUser, INode
	{
		public int ID { get; set; }

		public string? Username { get; set; }

		public Uri? ProfilePicture { get; set; }

		public IdentityInformation IdentityInformation { get; set; }

		public ContactInformation? ContactInformation { get; set; }

		[GraphQLDescription("Business or personal website for the personal trainer.")]
		public Uri? Website { get; set; }

		[GraphQLDescription("Certifications achieved by the personal trainer.")]
		public IEnumerable<Certification>? Certifications { get; set; }
	}
}
