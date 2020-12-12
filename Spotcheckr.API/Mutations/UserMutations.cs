using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;

namespace Spotcheckr.API.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class UserMutations
	{
		public async Task<CreateUserPayload> CreateUserAsync(CreateUserInput input, [Service] IUserService userService)
		{
			var newUser = userService.CreateUser(input.UserType);
			return new CreateUserPayload(newUser);
		}

		public async Task<DeleteUserPayload> DeleteUserAsync([ID] int id, [Service] IUserService userService)
		{
			_ = await userService.DeleteUserAsync(id);
			return new DeleteUserPayload(id);
		}
	}
}
