using System;

namespace Spotcheckr.Data.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository UserRepository { get; }

		IExercisePostRepository ExercisePostRepository { get; }

		int Complete();
	}
}
