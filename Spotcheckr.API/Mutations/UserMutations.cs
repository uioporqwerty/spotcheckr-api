using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations
{
	[ExtendObjectType(Name = "Mutation")]
	public class UserMutations
	{
		private readonly IMapper Mapper;

		public UserMutations(IMapper mapper)
		{
			Mapper = mapper;
		}

		public async Task<CreateUserPayload> CreateUserAsync(CreateUserInput input, [Service] IUserService userService)
		{
			var newUser = userService.CreateUser(input.UserType);
			return new CreateUserPayload(newUser);
		}

		public async Task<UpdateUserProfilePayload> UpdateUserProfileAsync(UpdateUserProfileInput input, [Service] IUserService userService)
		{
			var user = await userService.GetUserAsync(input.Id);
			var mappedUser = Mapper.Map(input, user, typeof(UpdateUserProfileInput), user.GetType()) as IUser;
			await userService.UpdateUserProfileAsync(mappedUser);
			return new UpdateUserProfilePayload(mappedUser);
		}

		public async Task<UpdateUserContactInformationPayload> UpdateUserContactInformationAsync(UpdateUserContactInformationInput input, [Service] IUserService userService)
		{
			var user = await userService.GetUserAsync(input.Id);
			var mappedUser = Mapper.Map(input, user, typeof(UpdateUserProfileInput), user.GetType()) as IUser;
			await userService.UpdateUserContactInformationAsync(mappedUser);
			return new UpdateUserContactInformationPayload(mappedUser);
		}

		public async Task<DeleteUserPayload> DeleteUserAsync(DeleteUserInput input, [Service] IUserService userService)
		{
			_ = await userService.DeleteUserAsync(input.Id);
			return new DeleteUserPayload(input.Id);
		}
	}
}
