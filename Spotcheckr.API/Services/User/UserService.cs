using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Spotcheckr.API.Data.Repositories;
using Spotcheckr.API.Models;

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
			var user = await UnitOfWork.Users.GetUserDetailsAsync(id);

			return (user?.Type) switch
			{
				Domain.UserType.PersonalTrainer => Mapper.Map<PersonalTrainer>(user),
				Domain.UserType.Athlete => Mapper.Map<Athlete>(user),
				_ => throw new Exception("Invalid user type."),
			};
		}

		public IUser CreateUser(UserType userType)
		{
			var user = new Domain.User { Type = userType == UserType.Athlete ? Domain.UserType.Athlete : Domain.UserType.PersonalTrainer };
			UnitOfWork.Users.Add(user);
			UnitOfWork.Complete();

			return userType switch
			{
				UserType.Athlete => Mapper.Map<Athlete>(user),
				UserType.PersonalTrainer => Mapper.Map<PersonalTrainer>(user),
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

		public Task<IUser> UpdateUserContactInformationAsync(int userId, ContactInformation updatedContactInformation)
		{
			var existingEmailAddresses = UnitOfWork.Emails.GetEmailsByUserId(userId);
			UpdateEmailAddresses(updatedContactInformation, existingEmailAddresses);

			var existingPhoneNumbers = UnitOfWork.PhoneNumbers.GetPhoneNumbersByUserId(userId);
			UpdatePhoneNumbers(updatedContactInformation, existingPhoneNumbers);

			UnitOfWork.Complete();

			return GetUserAsync(userId);
		}

		private static void UpdateEmailAddresses(ContactInformation updatedContactInformation, IEnumerable<Domain.Email> existingEmailAddresses)
		{
			var updatedEmailAddresses = new HashSet<Domain.Email>(updatedContactInformation.EmailAddresses.Select(email => new Domain.Email { Id = email.Id, Address = email.Address }) ?? Enumerable.Empty<Domain.Email>());
			foreach (var existingEmail in existingEmailAddresses)
			{
				if (updatedEmailAddresses.Contains(existingEmail))
				{
					existingEmail.Address = updatedEmailAddresses.Where(email => email.Id == existingEmail.Id).First().Address;
				}
			}
		}

		private static void UpdatePhoneNumbers(ContactInformation updatedContactInformation, IEnumerable<Domain.PhoneNumber> existingPhoneNumbers)
		{
			var updatedPhoneNumbers = new HashSet<Domain.PhoneNumber>(updatedContactInformation.PhoneNumbers.Select(phoneNumber => new Domain.PhoneNumber
			{
				Id = phoneNumber.Id,
				Number = phoneNumber.Number,
				Extension = phoneNumber.Extension
			}) ?? Enumerable.Empty<Domain.PhoneNumber>());
			foreach (var existingPhoneNumber in existingPhoneNumbers)
			{
				if (updatedPhoneNumbers.Contains(existingPhoneNumber))
				{
					var updatedPhoneNumber = updatedPhoneNumbers.Where(phoneNumber => phoneNumber.Id == existingPhoneNumber.Id).First();
					existingPhoneNumber.Number = updatedPhoneNumber.Number;
					existingPhoneNumber.Extension = updatedPhoneNumber.Extension;
				}
			}
		}
	}
}
