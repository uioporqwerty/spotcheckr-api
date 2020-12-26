using System.Threading.Tasks;
using Spotcheckr.API.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetUserDetailsAsync(int userID);
	}
}
