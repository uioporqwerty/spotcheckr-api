using System;
using System.Threading.Tasks;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services.User
{
	public class UserService : IUserService
	{
		public SpotcheckrCoreContext Context;

		public UserService(SpotcheckrCoreContext context)
		{
			Context = context;
		}

		public async Task<Athlete> GetAthleteAsync(int id)
		{
			using var unitOfWork = new UnitOfWork(Context);
			var user = await unitOfWork.Users.GetAsync(id);
			var userContactInformation = await unitOfWork.Users.GetContactInformationAsync(id);

			if (user?.Type != UserType.Athlete)
			{
				throw new Exception($"User is not an athlete. Requested user is a {user?.Type}.");
			}

			return new Athlete
			{
				Id = id,
				Username = user.Username,
				IdentityInformation = new IdentityInformation
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					BirthDate = user.BirthDate
				},
				ContactInformation = userContactInformation
			};
		}

		public async Task<PersonalTrainer> GetPersonalTrainerAsync(int id)
		{
			using var unitOfWork = new UnitOfWork(Context);
			var user = await unitOfWork.Users.GetAsync(id);
			var userContactInformation = await unitOfWork.Users.GetContactInformationAsync(id);

			if (user.Type != UserType.PersonalTrainer)
			{
				throw new Exception($"User is not a personal trainer. Requested user is a {user.Type.ToString()}.");
			}

			return new PersonalTrainer
			{
				Id = id,
				Username = user.Username,
				IdentityInformation = new IdentityInformation
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					BirthDate = user.BirthDate
				},
				ContactInformation = userContactInformation
			};
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
					Id = id,
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
					Id = id,
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
	}
}
