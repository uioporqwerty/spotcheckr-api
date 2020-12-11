using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class UserQueries
	{
		public async Task<IUser> GetUserAsync([ID(nameof(IUser))] int id, [Service] IUserService userService) => await userService.GetUser(id);
	}
}
