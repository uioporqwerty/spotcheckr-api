using Spotcheckr.API.Users;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain.Identifiers;

namespace Spotcheckr.API.Services.User
{
	public class UserService : IUserService
	{
		public SpotcheckrCoreContext _context;

		public UserService(SpotcheckrCoreContext context)
		{
			_context = context;
		}

		public PersonalTrainer GetPersonalTrainer(UserID id)
		{
			using (var unitOfWork = new UnitOfWork(_context))
			{
				var user = unitOfWork.Users.Get(id.Value);
				return new PersonalTrainer(user.Id, user.Username);
			}
		}
	}
}
