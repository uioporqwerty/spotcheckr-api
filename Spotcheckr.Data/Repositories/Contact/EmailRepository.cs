using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class EmailRepository : Repository<Email>, IEmailRepository
	{
		public EmailRepository(SpotcheckrCoreContext context) : base(context) { }

		public SpotcheckrCoreContext SpotcheckrCoreContext => Context as SpotcheckrCoreContext;

		public IEnumerable<Email> GetEmailsByUserId(int userId) => SpotcheckrCoreContext.Emails.Where(email => email.UserId == userId);
	}
}
