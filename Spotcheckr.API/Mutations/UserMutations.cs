using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class UserMutations
	{
		public CreateUserPayload CreateUser(CreateUserInput input, [Service] IUserService userService)
		{
			var newUser = userService.CreateUser(input.UserType);
			return new CreateUserPayload(newUser);
		}

		public async Task<DeleteUserPayload> DeleteUserAsync([ID(nameof(IUser))] int id, [Service] IUserService userService)
		{
			_ = await userService.DeleteUserAsync(id);
			return new DeleteUserPayload(id);
		}
	}
}
