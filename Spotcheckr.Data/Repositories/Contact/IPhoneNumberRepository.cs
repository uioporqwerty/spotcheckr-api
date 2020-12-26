using System.Collections.Generic;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public interface IPhoneNumberRepository : IRepository<PhoneNumber>
	{
		public IEnumerable<PhoneNumber> GetPhoneNumbersByUserId(int userId);
	}
}
