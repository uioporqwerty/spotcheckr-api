using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Services.User;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class UserQueries
	{
		public async Task<Athlete> GetAthleteAsync([ID(nameof(Athlete))]int id, [Service] IUserService userService) =>
			await userService.GetAthleteAsync(id);

		public async Task<PersonalTrainer> GetPersonalTrainerAsync([ID(nameof(PersonalTrainer))]int id,
			[Service] IUserService userService) => await userService.GetPersonalTrainerAsync(id);
	}
}
