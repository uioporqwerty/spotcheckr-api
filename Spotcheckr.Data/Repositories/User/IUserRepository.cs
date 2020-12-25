using System.Threading.Tasks;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetUserDetailsAsync(int userID);
	}
}
