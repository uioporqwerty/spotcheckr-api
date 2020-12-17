using System;

namespace Spotcheckr.Data.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }

		IExercisePostRepository ExercisePosts { get; }

		IEmailRepository Emails { get; }

		IPhoneNumberRepository PhoneNumbers { get; }

		int Complete();
	}
}
