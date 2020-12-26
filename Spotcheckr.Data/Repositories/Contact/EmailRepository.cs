using System.Collections.Generic;
using System.Linq;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public class EmailRepository : Repository<Email>, IEmailRepository
	{
		public EmailRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context;

		public IEnumerable<Email> GetEmailsByUserId(int userId) => SpotcheckrCoreContext.Emails.Where(email => email.UserId == userId);
	}
}
