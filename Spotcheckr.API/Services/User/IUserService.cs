﻿using System.Threading.Tasks;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Services
{
	public interface IUserService
	{
		Task<IUser> GetUserAsync(int id);

		IUser CreateUser(UserType userType);

		Task<IUser> UpdateUserProfileAsync(IUser updatedUser);

		Task<IUser> UpdateUserContactInformationAsync(int userId, ContactInformation updatedContactInformation);

		Task<int> DeleteUserAsync(int id);
	}
}
