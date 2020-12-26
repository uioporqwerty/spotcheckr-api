using System.Collections.Generic;
using System.Linq;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
	{
		public PhoneNumberRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context;

		public IEnumerable<PhoneNumber> GetPhoneNumbersByUserId(int userId) => SpotcheckrCoreContext.PhoneNumbers.Where(phoneNumber => phoneNumber.UserId == userId);
	}
}
