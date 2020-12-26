using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Services;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class UserQueries
	{
		/// <summary>
		/// Retrieve information about a user.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userService"></param>
		/// <returns></returns>
		public async Task<IUser> GetUserAsync([ID] int id, [Service] IUserService userService) => await userService.GetUserAsync(id);
	}
}
