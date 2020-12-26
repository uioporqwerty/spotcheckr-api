using System.Collections.Generic;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public interface IEmailRepository : IRepository<Email>
	{
		public IEnumerable<Email> GetEmailsByUserId(int userId);
	}
}
