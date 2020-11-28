using System;
using Spotcheckr.API.Repositories.Post;

namespace Spotcheckr.API.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository UserRepository { get; }

		IExercisePostRepository ExercisePostRepository { get; }

		int Complete();
	}
}
