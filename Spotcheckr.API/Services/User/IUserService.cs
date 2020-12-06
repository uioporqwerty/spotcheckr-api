using System.Threading.Tasks;
using Spotcheckr.API.Types.Users;

namespace Spotcheckr.API.Services.User
{
	public interface IUserService
	{
		Task<Athlete> GetAthlete(int id);

		Task<PersonalTrainer> GetPersonalTrainer(int id);
	}
}
