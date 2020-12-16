using System;
using HotChocolate.Types.Relay;

namespace Spotcheckr.API.Mutations.Inputs
{
	public record UpdateUserProfileInput([ID] int Id,
											  string Username,
											  string FirstName,
											  string MiddleName,
											  string LastName,
											  DateTime BirthDate);
}
