using System.Linq;
using System.Threading.Tasks;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context as SpotcheckrCoreContext;

		public Task<ContactInformation> GetContactInformationAsync(int userID)
		{
			var emails = SpotcheckrCoreContext.Emails.Where(email => email.UserId == userID).ToList();
			var phoneNumbers = SpotcheckrCoreContext.PhoneNumbers.Where(phoneNumber => phoneNumber.UserId == userID).ToList();

			var contactInformation = new ContactInformation
			{
				EmailAddresses = emails,
				PhoneNumbers = phoneNumbers
			};

			return Task.FromResult(contactInformation);
		}
	}
}
