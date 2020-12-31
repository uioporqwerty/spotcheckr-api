using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Models;
using Spotcheckr.API.Services;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Xunit;

namespace Spotcheckr.API.UnitTests.Services
{
	[Collection("Service collection")]
	public class ExercisePostServiceTests : BaseTest
	{
		private readonly IExercisePostService Service;

		public ExercisePostServiceTests(ServiceFixture serviceFixture) : base(serviceFixture)
		{
			Service = serviceFixture.ServiceProvider.GetRequiredService<IExercisePostService>();
		}

		[Fact]
		public async void GetExercisePost_WithValidPost_ReturnsPost()
		{
			var postCreator = new Domain.User
			{
				FirstName = "Nitish",
				LastName = "Sachar",
				Type = Domain.UserType.Athlete
			};
			UnitOfWork.Users.Add(postCreator);
			var newPost = new Domain.ExercisePost
			{
				CreatedById = postCreator.Id,
				Title = "Hello World",
				Description = "Goodbye World",
				DateCreated = SpotcheckrTimeUtilities.CurrentTime,
				DateModified = SpotcheckrTimeUtilities.CurrentTime
			};
			UnitOfWork.ExercisePosts.Add(newPost);
			UnitOfWork.Complete();
			var result = await Service.GetExercisePost(newPost.Id);
			Assert.Equal("Hello World", result.Title);
		}
	}
}
