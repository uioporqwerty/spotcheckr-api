using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(SpotcheckrCoreContext context) : base(context) { }
	}
}
