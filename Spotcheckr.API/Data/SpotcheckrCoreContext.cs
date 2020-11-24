using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data
{
	public class SpotcheckrCoreContext : DbContext
	{
		public DbSet<User> Users { get; set; } = default!;

		public DbSet<Organization> Organizations { get; set; } = default!;

		public DbSet<Certificate> Certificates { get; set; } = default!;

		public SpotcheckrCoreContext(DbContextOptions<SpotcheckrCoreContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(prop => prop.Height).HasColumnType("decimal").HasPrecision(2);
			modelBuilder.Entity<User>()
				.Property(prop => prop.Weight).HasColumnType("decimal").HasPrecision(2);
			modelBuilder.Entity<Email>().ToTable("Emails");
			modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumbers");
			modelBuilder.Entity<Certification>().ToTable("Certifications");
			modelBuilder.Entity<Company>().ToTable("Companies");
		}
	}
}
