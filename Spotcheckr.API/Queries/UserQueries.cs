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
		public async Task<IUser> GetUserAsync(int id, [Service] IUserService userService) => await userService.GetUserAsync(id);
	}
}
