using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Mutations.Payloads;
using Spotcheckr.API.Services;
using Spotcheckr.Models;

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

		/// <summary>
		/// Create an Athlete or Personal Trainer type of user.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="userService"></param>
		/// <returns></returns>
		public async Task<CreateUserPayload> CreateUserAsync(CreateUserInput input, [Service] IUserService userService)
		{
			var newUser = userService.CreateUser(input.UserType);
			return new CreateUserPayload(newUser);
		}

		/// <summary>
		/// Update user profile information.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="userService"></param>
		/// <returns></returns>
		public async Task<UpdateUserProfilePayload> UpdateUserProfileAsync(UpdateUserProfileInput input, [Service] IUserService userService)
		{
			var user = await userService.GetUserAsync(input.Id);
			var mappedUser = Mapper.Map(input, user, typeof(UpdateUserProfileInput), user.GetType()) as IUser;
			await userService.UpdateUserProfileAsync(mappedUser);
			return new UpdateUserProfilePayload(mappedUser);
		}

		/// <summary>
		/// Update user contact information.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="userService"></param>
		/// <returns></returns>
		public async Task<UpdateUserContactInformationPayload> UpdateUserContactInformationAsync(UpdateUserContactInformationInput input, [Service] IUserService userService)
		{
			var updatedContactInformation = Mapper.Map<ContactInformation>(input);
			var user = await userService.UpdateUserContactInformationAsync(input.Id, updatedContactInformation);
			return new UpdateUserContactInformationPayload(user);
		}

		/// <summary>
		/// Delete a user and all of their related information. This operation is permanent.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="userService"></param>
		/// <returns></returns>
		public async Task<DeleteUserPayload> DeleteUserAsync(DeleteUserInput input, [Service] IUserService userService)
		{
			_ = await userService.DeleteUserAsync(input.Id);
			return new DeleteUserPayload(input.Id);
		}
	}
}
