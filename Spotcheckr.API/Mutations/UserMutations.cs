using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class UserMutations
	{
		public CreateUserPayload CreateUser(UserType userType, [Service] IUserService userService)
		{
			var newUser = userService.CreateUser(userType);
			return new CreateUserPayload(newUser);
		}
	}
}
