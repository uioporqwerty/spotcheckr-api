﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Services;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Spotcheckr.Models;
using Xunit;

namespace Spotcheckr.API.UnitTests.Services
{
	public class UserServiceTests : BaseTest
	{
		private readonly IUserService Service;

		public UserServiceTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
			Service = serviceFixture.ServiceProvider.GetRequiredService<IUserService>();
		}

		[Fact]
		public async void GetUserAsync_WithInvalidUser_ThrowsException()
		{
			Assert.ThrowsAsync<InvalidOperationException>(() => Service.GetUserAsync(-1));
		}

		[Fact]
		public void CreateUser_UserTypeAthlete_CreatesAthleteUser()
		{
			var result = Service.CreateUser(Models.UserType.Athlete);
			Assert.IsType<Athlete>(result);
		}

		[Fact]
		public void CreateUser_UserTypePersonalTrainer_CreatesPersonalTrainerUser()
		{
			var result = Service.CreateUser(Models.UserType.PersonalTrainer);
			Assert.IsType<PersonalTrainer>(result);
		}
	}
}