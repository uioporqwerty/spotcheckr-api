using System;

namespace Spotcheckr.Domain
{
	public class PostMetrics : IEntityTracking
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public int? ExercisePostId { get; set; }

		public ExercisePost ExercisePost { get; set; }

		public int? CommentId { get; set; }

		public Comment Comment { get; set; }

		public VoteType Vote { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
