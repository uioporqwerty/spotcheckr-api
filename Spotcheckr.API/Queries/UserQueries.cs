using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Services.User;
using Spotcheckr.API.Users;
using Spotcheckr.Domain.Identifiers;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class UserQueries
	{
		public IUser GetUser(int id, [Service] IUserService userService) =>
			userService.GetPersonalTrainer(new UserID(id));
	}
}
