using System;

namespace Spotcheckr.API.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		int Complete();
	}
}
