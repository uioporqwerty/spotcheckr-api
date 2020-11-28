using Spotcheckr.API.Data;
using Spotcheckr.API.Repositories.Post;

namespace Spotcheckr.API.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SpotcheckrCoreContext _context;

		public IUserRepository UserRepository { get; }
		public IExercisePostRepository ExercisePostRepository { get; }

		public UnitOfWork(SpotcheckrCoreContext context)
		{
			_context = context;

			UserRepository = new UserRepository(_context);
			ExercisePostRepository = new ExercisePostRepository(_context);
		}

		public void Dispose() => _context.Dispose();

		public int Complete() => _context.SaveChanges();
	}
}
