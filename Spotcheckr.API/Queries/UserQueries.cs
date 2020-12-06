using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Services.User;
using Spotcheckr.API.Types.Users;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class UserQueries
	{
		public async Task<Athlete> GetAthleteAsync([ID(nameof(Athlete))]int id, [Service] IUserService userService) =>
			await userService.GetAthlete(id);

		public async Task<PersonalTrainer> GetPersonalTrainerAsync([ID(nameof(PersonalTrainer))] int id,
			[Service] IUserService userService) => await userService.GetPersonalTrainer(id);
	}
}
