using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spotcheckr.API.Tests.Common;
using Spotcheckr.API.Tests.Common.Fixtures;
using Spotcheckr.Data;
using Spotcheckr.Data.Repositories;
using Xunit;

namespace Spotcheckr.API.Tests.Common
{
	public abstract class BaseTest : IClassFixture<ServiceFixture>, IDisposable
	{
		protected readonly ServiceProvider ServiceProvider;

		protected readonly IUnitOfWork UnitOfWork;

		private readonly SpotcheckrCoreContext Context;

		public BaseTest(ServiceFixture serviceFixture)
		{
			ServiceProvider = serviceFixture.ServiceProvider;
			Context = serviceFixture.ServiceProvider.GetRequiredService<SpotcheckrCoreContext>();
			UnitOfWork = serviceFixture.ServiceProvider.GetRequiredService<IUnitOfWork>();

			Context.Database.EnsureCreated();
		}

		public void Dispose()
		{
			Context.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
			Context.Database.EnsureDeleted();
		}
	}
}
