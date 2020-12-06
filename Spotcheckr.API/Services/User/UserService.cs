using System.Threading.Tasks;
using Spotcheckr.API.Types.Identity;
using Spotcheckr.API.Types.Users;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;

namespace Spotcheckr.API.Services.User
{
	public class UserService : IUserService
	{
		public SpotcheckrCoreContext Context;

		public UserService(SpotcheckrCoreContext context)
		{
			Context = context;
		}

		public Task<Athlete> GetAthlete(int id)
		{
			using var unitOfWork = new UnitOfWork(Context);
			var user = unitOfWork.Users.Get(id);

			return Task.FromResult(new Athlete
			{
				ID = id,
				Username = user.Username,
				IdentityInformation = new IdentityInformation
				{
					FirstName = user.FirstName, LastName = user.LastName, BirthDate = user.BirthDate
				}
			});
		}

		public Task<PersonalTrainer> GetPersonalTrainer(int id)
		{
			using var unitOfWork = new UnitOfWork(Context);
			var user = unitOfWork.Users.Get(id);

			return Task.FromResult(new PersonalTrainer
			{
				ID = id,
				Username = user.Username,
				IdentityInformation = new IdentityInformation
				{
					FirstName = user.FirstName, LastName = user.LastName, BirthDate = user.BirthDate
				}
			});
		}
	}
}
