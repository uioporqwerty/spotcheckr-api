using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Spotcheckr.Data.Repositories;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Services
{
	public class UserService : IUserService
	{
		private readonly IMapper Mapper;

		private readonly IUnitOfWork UnitOfWork;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			Mapper = mapper;
		}

		public async Task<IUser> GetUserAsync(int id)
		{
			var user = await UnitOfWork.Users.GetAsync(id);
			var userContactInformation = await UnitOfWork.Users.GetContactInformationAsync(id);

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
		}

		public IUser CreateUser(UserType userType)
		{
			var user = new User { Type = userType };
			UnitOfWork.Users.Add(user);
			UnitOfWork.Complete();

			return userType switch
			{
				UserType.Athlete => new Athlete
				{
					Id = user.Id
				},
				UserType.PersonalTrainer => new PersonalTrainer
				{
					Id = user.Id
				},
				_ => throw new Exception("Unrecognized user type.")
			};
		}

		public async Task<int> DeleteUserAsync(int id)
		{
			var user = await UnitOfWork.Users.GetAsync(id);

			if (user == null)
			{
				throw new Exception($"User {id} does not exist.");
			}

			UnitOfWork.Users.Remove(user);
			UnitOfWork.Complete();

			return user.Id;
		}

		public async Task<IUser> UpdateUserProfileAsync(IUser updatedUser)
		{
			var user = await UnitOfWork.Users.GetAsync(updatedUser.Id);

			user.Username = updatedUser.Username;
			user.FirstName = updatedUser.IdentityInformation?.FirstName;
			user.MiddleName = updatedUser.IdentityInformation?.MiddleName;
			user.LastName = updatedUser.IdentityInformation?.LastName;
			user.BirthDate = updatedUser.IdentityInformation?.BirthDate;

			UnitOfWork.Complete();

			return updatedUser;
		}

		public Task<IUser> UpdateUserContactInformation(int userId, ContactInformation updatedContactInformation)
		{
			var existingEmailAddresses = UnitOfWork.Emails.GetEmailsByUserId(userId);
			var updatedEmailAddresses = new HashSet<Email>(updatedContactInformation.EmailAddresses.Select(email => email) ?? Enumerable.Empty<Email>());
			foreach (var existingEmail in existingEmailAddresses)
			{
				if (updatedEmailAddresses.Contains(existingEmail))
				{
					existingEmail.Address = updatedEmailAddresses.Where(email => email.Id == existingEmail.Id).First().Address;
				}
			}

			UnitOfWork.Complete();
			return GetUserAsync(userId);
		}
	}
}
