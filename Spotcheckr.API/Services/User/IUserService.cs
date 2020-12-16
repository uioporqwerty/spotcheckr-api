using System.Threading.Tasks;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public interface IUserService
	{
		Task<IUser> GetUserAsync(int id);

		IUser CreateUser(UserType userType);

		Task<IUser> UpdateUserProfileAsync(IUser updatedUser);

		Task<IUser> UpdateUserContactInformationAsync(IUser updatedUser);

		Task<int> DeleteUserAsync(int id);
	}
}
