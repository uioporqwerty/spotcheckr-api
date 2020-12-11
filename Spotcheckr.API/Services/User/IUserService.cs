using System.Threading.Tasks;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public interface IUserService
	{
		Task<IUser> GetUser(int id);

		IUser CreateUser(UserType userType);
	}
}
