using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(SpotcheckrCoreContext context) : base(context) { }
		
		public SpotcheckrCoreContext SpotcheckrCoreContext => Context as SpotcheckrCoreContext;

		public Task<ContactInformation?> GetContactInformationAsync(int userID)
		{
			var user = SpotcheckrCoreContext.Users.Where(user => user.Id == userID)
				.Include(users => users.PhoneNumbers)
				.Include(users => users.Emails).FirstOrDefault();

			ContactInformation? contactInformation = null;

			if (user != null)
			{
				contactInformation = new ContactInformation
				{
					EmailAddresses = user.Emails,
					PhoneNumbers = user.PhoneNumbers
				};
			}

			return Task.FromResult(contactInformation);
		}
	}
}
