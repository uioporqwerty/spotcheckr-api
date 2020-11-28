using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data
{
	public class SpotcheckrCoreContext : DbContext
	{
		public DbSet<User> Users { get; set; } = default!;

		public DbSet<ExercisePost> ExercisePosts { get; set; } = default!;

		public DbSet<Comment> Comments { get; set; } = default!;

		public DbSet<Organization> Organizations { get; set; } = default!;

		public DbSet<Certificate> Certificates { get; set; } = default!;

		public SpotcheckrCoreContext(DbContextOptions<SpotcheckrCoreContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(prop => prop.Type).HasConversion<int>();

			modelBuilder.Entity<Certification>()
				.HasOne(prop => prop.User)
				.WithMany(prop => prop.Certifications)
				.HasForeignKey(prop => prop.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Email>()
				.HasOne(prop => prop.User)
				.WithMany(prop => prop.Emails)
				.HasForeignKey(prop => prop.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<PhoneNumber>()
				.HasOne(prop => prop.User)
				.WithMany(prop => prop.PhoneNumbers)
				.HasForeignKey(prop => prop.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

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
		}
	}
}
