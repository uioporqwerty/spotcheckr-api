using System;

namespace Spotcheckr.Data.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }

		IExercisePostRepository ExercisePosts { get; }

		int Complete();
	}
}
