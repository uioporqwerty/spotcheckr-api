using Microsoft.EntityFrameworkCore;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Data
{
	public sealed class SpotcheckrCoreContext : DbContext
	{
		public DbSet<User> Users { get; set; } = default!;

		public DbSet<Email> Emails { get; set; } = default!;

		public DbSet<PhoneNumber> PhoneNumbers { get; set; } = default!;

		public DbSet<ExercisePost> ExercisePosts { get; set; } = default!;

		public DbSet<Comment> Comments { get; set; } = default!;

		public DbSet<Organization> Organizations { get; set; } = default!;

		public DbSet<Certificate> Certificates { get; set; } = default!;

		public DbSet<Certification> Certifications { get; set; } = default!;

		public SpotcheckrCoreContext(DbContextOptions<SpotcheckrCoreContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>()
				.ToTable("Companies")
				.Property(prop => prop.Name).HasMaxLength(255);

			modelBuilder.Entity<User>()
				.Property(prop => prop.Type).HasConversion<int>();

			modelBuilder.Entity<User>()
				.Property(prop => prop.FirstName).HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(prop => prop.LastName).HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(prop => prop.MiddleName).HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(prop => prop.Username).HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(prop => prop.Website).HasMaxLength(2000);

			modelBuilder.Entity<User>()
				.Property(prop => prop.Height).HasColumnType("decimal(6, 2)");

			modelBuilder.Entity<User>()
				.Property(prop => prop.Weight).HasColumnType("decimal(5, 2)");

			modelBuilder.Entity<Certification>()
				.ToTable("Certifications")
				.HasOne(prop => prop.User)
				.WithMany(prop => prop.Certifications)
				.HasForeignKey(prop => prop.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Certification>()
				.Property(prop => prop.Verified).HasDefaultValue(false);

			modelBuilder.Entity<Email>()
				.ToTable("Emails")
				.HasOne(prop => prop.User)
				.WithMany(prop => prop.Emails)
				.HasForeignKey(prop => prop.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Email>()
				.Property(prop => prop.Address).HasMaxLength(254);

			modelBuilder.Entity<PhoneNumber>()
				.ToTable("PhoneNumbers")
				.HasOne(prop => prop.User)
				.WithMany(prop => prop.PhoneNumbers)
				.HasForeignKey(prop => prop.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<PhoneNumber>()
				.Property(prop => prop.Number).HasMaxLength(15);

			modelBuilder.Entity<PhoneNumber>()
				.Property(prop => prop.Extension).HasMaxLength(11);

			modelBuilder.Entity<PostMetrics>()
				.Property(prop => prop.Vote).HasConversion<int>();

			modelBuilder.Entity<PostMetrics>()
				.HasOne(prop => prop.ExercisePost)
				.WithMany()
				.HasForeignKey(prop => prop.ExercisePostId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<PostMetrics>()
				.HasOne(prop => prop.Comment)
				.WithMany()
				.HasForeignKey(prop => prop.CommentId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Media>()
				.Property(prop => prop.Type).HasConversion<int>();

			modelBuilder.Entity<Media>()
				.HasOne(prop => prop.ExercisePost)
				.WithMany(prop => prop.Media)
				.HasForeignKey(prop => prop.ExercisePostId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Media>()
				.HasOne(prop => prop.Comment)
				.WithMany(prop => prop.Media)
				.HasForeignKey(prop => prop.CommentId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Media>()
				.Property(prop => prop.URL).HasMaxLength(2000);

			modelBuilder.Entity<Comment>()
				.ToTable("Comments")
				.Property(prop => prop.Text).HasMaxLength(10000);

			modelBuilder.Entity<ExercisePost>()
				.ToTable("ExercisePosts")
				.Property(prop => prop.Title).HasMaxLength(1000);

			modelBuilder.Entity<ExercisePost>()
				.Property(prop => prop.Description).HasMaxLength(10000);
		}
	}
}
