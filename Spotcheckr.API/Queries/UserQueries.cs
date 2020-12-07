using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Spotcheckr.API.Services.User;
using Spotcheckr.API.Types.Users;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class UserQueries
	{
		public async Task<Athlete> GetAthleteAsync(int id, [Service] IUserService userService) =>
			await userService.GetAthleteAsync(id);

		public async Task<PersonalTrainer> GetPersonalTrainerAsync(int id,
			[Service] IUserService userService) => await userService.GetPersonalTrainerAsync(id);
	}
}
