using Spotcheckr.API.Users;
using Spotcheckr.Domain.Identifiers;

namespace Spotcheckr.API.Services.User
{
	public interface IUserService
	{
		PersonalTrainer GetPersonalTrainer(UserID id);
	}
}
