using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Spotcheckr.API.Data;

namespace Spotcheckr.API.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(SpotcheckrCoreContext context) : base(context) { }
	}
}
