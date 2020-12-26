using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotcheckr.API.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context;

		public Task<User> GetUserDetailsAsync(int userID)
		{
			var user = SpotcheckrCoreContext.Users.Where(user => user.Id == userID)
												  .Include(user => user.Emails)
												  .Include(user => user.PhoneNumbers)
												  .Include(user => user.Certifications).FirstOrDefault();
			if (user == null)
			{
				throw new InvalidOperationException($"User {userID} not found.");
			}

			return Task.FromResult(user);
		}
	}
}
