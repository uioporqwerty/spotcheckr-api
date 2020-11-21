using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data
{
	public class SpotcheckrCoreContext : DbContext
	{
		public DbSet<User> Users { get; set; } = default!;

		public SpotcheckrCoreContext(DbContextOptions<SpotcheckrCoreContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Email>().ToTable("Emails");
			modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumbers");
			modelBuilder.Entity<Certificate>().ToTable("Certificates");
			modelBuilder.Entity<Certification>().ToTable("Certifications");
			modelBuilder.Entity<Company>().ToTable("Companies");
			modelBuilder.Entity<Organization>().ToTable("Organizations");
		}
	}
}
