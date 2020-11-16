using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data
{
	public class SpotcheckrCoreContext : DbContext
	{
		public DbSet<User> Users { get; set; } = default!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				"Server=tcp:spotcheckr-sql.database.windows.net,1433;Initial Catalog=Core;Persist Security Info=False;User ID=nsachar;Password=qN42ZxxGm!J!%F6L&6vV;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
		}
	}
}
