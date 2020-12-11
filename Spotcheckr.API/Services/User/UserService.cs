using System;
using System.Threading.Tasks;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public class UserService : IUserService
	{
		public SpotcheckrCoreContext Context;

		public UserService(SpotcheckrCoreContext context)
		{
			Context = context;
		}

		public async Task<IUser> GetUser(int id)
		{
			using var unitOfWork = new UnitOfWork(Context);
			var user = await unitOfWork.Users.GetAsync(id);
			var userContactInformation = await unitOfWork.Users.GetContactInformationAsync(id);

			return (user?.Type) switch
			{
				UserType.PersonalTrainer => new PersonalTrainer
				{
					Id = id.ToString(),
					Username = user.Username,
					IdentityInformation = new IdentityInformation
					{
						FirstName = user.FirstName,
						LastName = user.LastName,
						BirthDate = user.BirthDate
					},
					ContactInformation = userContactInformation
				},
				UserType.Athlete => new Athlete
				{
					Id = id.ToString(),
					Username = user.Username,
					IdentityInformation = new IdentityInformation
					{
						FirstName = user.FirstName,
						LastName = user.LastName,
						BirthDate = user.BirthDate
					},
					ContactInformation = userContactInformation
				},
				_ => throw new Exception("Invalid user type."),
			};
			throw new Exception("User not found.");
		}

		public IUser CreateUser(UserType userType)
		{
			using var unitOfWork = new UnitOfWork(Context);

			var user = new User { Type = userType };
			unitOfWork.Users.Add(user);
			unitOfWork.Complete();

			return userType switch
			{
				UserType.Athlete => new Athlete
				{
					Id = user.Id.ToString()
				},
				UserType.PersonalTrainer => new PersonalTrainer
				{
					Id = user.Id.ToString()
				},
				_ => throw new Exception("Unrecognized user type.")
			};
		}
	}
}
