using System.Threading.Tasks;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services.User
{
	public interface IUserService
	{
		Task<Athlete> GetAthleteAsync(int id);

		Task<PersonalTrainer> GetPersonalTrainerAsync(int id);
	}
}
