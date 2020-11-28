using Spotcheckr.API.Data;

namespace Spotcheckr.API.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SpotcheckrCoreContext _context;

		public UnitOfWork(SpotcheckrCoreContext context)
		{
			_context = context;
		}

		public void Dispose() => _context.Dispose();

		public int Complete() => _context.SaveChanges();
	}
}
