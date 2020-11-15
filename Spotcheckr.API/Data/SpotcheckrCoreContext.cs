using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data
{
	public class SpotcheckrCoreContext : DbContext
	{
		public DbSet<User> Users { get; set; } = default!;

		public SpotcheckrCoreContext(DbContextOptions<SpotcheckrCoreContext> options) : base(options) { } 
	}
}
