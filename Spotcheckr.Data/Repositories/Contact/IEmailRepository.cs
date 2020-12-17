using System.Collections.Generic;
using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public interface IEmailRepository : IRepository<Email>
	{
		public IEnumerable<Email> GetEmailsByUserId(int userId);
	}
}
