using System;
using HotChocolate;

namespace Spotcheckr.API.Types.Identity
{
	public class IdentityInformation
	{
		[GraphQLDescription("User first name.")]
		public string FirstName { get; set; }

		[GraphQLDescription("User last name.")]
		public string LastName { get; set; }

		[GraphQLDescription("User full name.")]
		public string FullName => $"{FirstName} {LastName}";

		[GraphQLDescription("User birth date.")]
		public DateTime? BirthDate { get; set; }
	}
}
