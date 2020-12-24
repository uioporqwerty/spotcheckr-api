using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context;

		public Task<User> GetUserDetailsWithContactInformationAsync(int userID)
		{
			var user = SpotcheckrCoreContext.Users.Where(user => user.Id == userID)
												  .Include(user => user.Emails)
												  .Include(user => user.PhoneNumbers).FirstOrDefault();
			if (user == null)
			{
				throw new InvalidOperationException($"User {userID} not found.");
			}

			return Task.FromResult(user);
		}
	}
}
