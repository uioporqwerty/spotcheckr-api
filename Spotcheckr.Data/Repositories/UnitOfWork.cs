namespace Spotcheckr.Data.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SpotcheckrCoreContext _context;

		public IUserRepository Users { get; }

		public IExercisePostRepository ExercisePosts { get; }

		public UnitOfWork(SpotcheckrCoreContext context)
		{
			_context = context;

			Users = new UserRepository(_context);
			ExercisePosts = new ExercisePostRepository(_context);
		}

		public void Dispose() => _context.Dispose();

		public int Complete() => _context.SaveChanges();
	}
}
